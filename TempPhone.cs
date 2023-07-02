using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TempPhone.Properties;
using WebSocketSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TempPhone
{
    public partial class TempPhone : Form
    {
        public static Thread messageloggerthread = new Thread(() => { });
        public static List<Number> numbers = new List<Number>();
        public static Settings settings = new Settings();
        public TempPhone()
        {
            InitializeComponent();
            settings = settings.Load();
            messageloggerthread = new Thread(MessageLoggerThread);
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                if (numbers.Count == 0)
                {
                    try { numbers = quackr_wrapper.loadNumbers(); }
                    catch { try { numbers = quackr_wrapper.fetchNumbers(); } catch { MessageBox.Show("Failed to load numbers from quackr.io and numbers.json", "TempPhone", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }
                    LoadNumbers();
                    messageloggerthread.Start();
                }

                List<Message> messages = new List<Message>();
                dynamic json = JsonConvert.DeserializeObject(e.Data);

                // check if message list incoming
                if (json.d.b != null && json.d.b.s == "ok" && json.d.b.d != null)
                {
                    foreach (dynamic message in json.d.b.d)
                    {
                        messages.Add(new Message
                        {
                            locale = message.Value.locale,
                            message = HttpUtility.HtmlDecode(message.Value.message.ToString()).Replace("\n", " ").Replace("\r", ""),
                            recipient = message.Value.recipient,
                            sender = message.Value.sender,
                            timestamp = message.Value.timestamp
                        });
                    }
                }
                else
                    return;

                // sort messages by timestamp so newest messages are at the top
                messages = messages.OrderByDescending(x => x.timestamp).ToList();
                bool isCurrentNumber = false;
                cbNumbersList.Invoke((MethodInvoker)delegate
                {
                    isCurrentNumber = numbers[cbNumbersList.SelectedIndex].number == messages.First().recipient;

                    // add new messages that is not already in messages
                    foreach (Message message in messages)
                        if (!numbers[cbNumbersList.SelectedIndex].messages.Any(x => x.timestamp == message.timestamp))
                            numbers[cbNumbersList.SelectedIndex].messages.Add(message);

                    // sort
                    numbers[cbNumbersList.SelectedIndex].messages = numbers[cbNumbersList.SelectedIndex].messages.OrderByDescending(x => x.timestamp).ToList();
                });

                // get scroll position
                lvMessages.Invoke((MethodInvoker)delegate { lvMessages.BeginUpdate(); }); // begin update to prevent flickering
                Point scrollpos = new Point();
                lvMessages.Invoke((MethodInvoker)delegate { scrollpos = lvMessages.AutoScrollOffset; });
                List<int> selecteditems = new List<int>();
                lvMessages.Invoke((MethodInvoker)delegate
                {
                    foreach (ListViewItem item in lvMessages.SelectedItems)
                        selecteditems.Add(item.Index);
                });

                if (isCurrentNumber && !copyMenu.Visible)
                    lvMessages.Invoke((MethodInvoker)delegate { lvMessages.Items.Clear(); }); // clear listview
                
                foreach (Message message in messages)
                {
                    string[] arr = new string[4];
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    dt = dt.AddMilliseconds(message.timestamp).ToLocalTime();
                    TimeSpan ts = DateTime.Now - dt;
                    // convert to minutes ago, hours ago, days ago, etc
                    if (ts.TotalMinutes < 1) arr[0] = "Just now";
                    else if (ts.TotalMinutes < 60) arr[0] = $"{Math.Round(ts.TotalMinutes)} minutes ago - {dt.ToString("hh:mm")}";
                    else if (ts.TotalHours < 24) arr[0] = $"{Math.Round(ts.TotalHours)} hours ago - {dt.ToString("hh:mm")}";
                    else if (ts.TotalDays < 7) arr[0] = $"{Math.Round(ts.TotalDays)} days ago - {dt.ToString("hh:mm")}";
                    else arr[0] = $"{dt.Month}/{dt.Day}/{dt.Year} - {dt.ToString("hh:mm")}";

                    arr[1] = message.sender;
                    arr[2] = message.message;

                    if (isCurrentNumber && !copyMenu.Visible)
                        lvMessages.Invoke((MethodInvoker)delegate { lvMessages.Items.Add(new ListViewItem(arr)); });

                    // if logger is enabled on recipient number, log message
                    if (numbers.Any(x => x.number == message.recipient && x.logmessages))
                    {
                        string log = $"{message.timestamp} | {dt.ToString("MM/dd/yyyy hh:mm")} | +{message.recipient} -> {message.sender}: {message.message}";
                        string logPath = $"{Application.StartupPath}\\logs\\{message.recipient}.txt";
                        if (!File.Exists(logPath)) File.WriteAllText(logPath, log);

                        // check if log entry already exists
                        if (!File.Exists(logPath) || !File.ReadAllText(logPath).Contains(log))
                        {
                            // append from the top (so newest messages are at the top)
                            string[] lines = File.ReadAllLines(logPath);
                            List<string> newLines = new List<string>();
                            newLines.Add(log);
                            foreach (string line in lines) newLines.Add(line);
                            newLines = newLines.OrderByDescending(x => long.Parse(x.Split('|')[0])).ToList();
                            File.WriteAllLines(logPath, newLines.ToArray());
                        }

                        // log also to global.txt
                        logPath = $"{Application.StartupPath}\\logs\\global.txt";
                        if (!File.Exists(logPath)) File.WriteAllText(logPath, log);

                        if (!File.Exists(logPath) || !File.ReadAllText(logPath).Contains(log))
                        {
                            // read all lines and add to list, sort by timestamp, then write to file
                            string[] lines = File.ReadAllLines(logPath);
                            List<string> newLines = new List<string>();
                            newLines.Add(log);
                            foreach (string line in lines) newLines.Add(line);
                            newLines = newLines.OrderByDescending(x => long.Parse(x.Split('|')[0])).ToList();
                            File.WriteAllLines(logPath, newLines.ToArray());
                        }
                    }
                }

                // if no messages, show "No Messages" in listview
                if (lvMessages.Items.Count == 0 && isCurrentNumber && !copyMenu.Visible)
                    lvMessages.Invoke((MethodInvoker)delegate { lvMessages.Items.Add(new ListViewItem(new string[] { "No Messages", "", "" })); });

                lvMessages.Invoke((MethodInvoker)delegate { lvMessages.AutoScrollOffset = scrollpos; }); // set scroll position
                lvMessages.Invoke((MethodInvoker)delegate
                {
                    // select previously selected items
                    foreach (int index in selecteditems)
                        lvMessages.Items[index].Selected = true;
                });
                lvMessages.Invoke((MethodInvoker)delegate { lvMessages.EndUpdate(); }); // end update to prevent flickering


                quackr_wrapper.saveNumbers(numbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured. Please try again.\n\n" + ex.Message, "TempPhone", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startWithWindowsToolStripMenuItem.Checked = settings.startWithWindows;
            startMinimizedToolStripMenuItem.Checked = settings.startMinimized;
            startMinimizedToolStripMenuItem.Enabled = settings.startWithWindows;

            // loop all cbRefreshInterval.Items and find the one that matches settings.refreshInterval
            for (int i = 0; i < cbRefreshInterval.Items.Count; i++)
            {
                if (int.Parse(cbRefreshInterval.Items[i].ToString().Split(' ')[0]) == settings.refreshinterval)
                {
                    cbRefreshInterval.SelectedIndex = i;
                    break;
                }
            }

            if (cbRefreshInterval.SelectedIndex == -1)
                cbRefreshInterval.SelectedIndex = 1; // def ault to 5 seconds

            if (settings.startMinimized)
            {   
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.ShowInTaskbar = false;
            }

            if (!Directory.Exists($"{Application.StartupPath}\\logs"))
                Directory.CreateDirectory($"{Application.StartupPath}\\logs");


            ConnectToWebsocket();
        }

        private void ConnectToWebsocket()
        {
            quackr_wrapper.ws = new WebSocket(quackr_wrapper.wss);
            quackr_wrapper.ws.WaitTime = TimeSpan.FromSeconds(5);
            quackr_wrapper.ws.Connect();
            quackr_wrapper.ws.OnMessage += Ws_OnMessage;
            quackr_wrapper.ws.OnError += Ws_OnError;
            quackr_wrapper.ws.OnClose += Ws_OnClose;
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            MessageBox.Show("Connection to API has been closed. Please try again.", "TempPhone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ConnectToWebsocket();
        }

        private void Ws_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            MessageBox.Show("An error has occured. Please try again.\n\n" + e.Message, "TempPhone", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ConnectToWebsocket();
        }

        private void LoadNumbers()
        {
            // save selected number to reselect after (index change)
            string selectedNumber = "";
            cbNumbersList.Invoke((MethodInvoker)delegate {
                if (cbNumbersList.SelectedIndex != -1)
                    selectedNumber = numbers[cbNumbersList.SelectedIndex].number;

                cbNumbersList.Items.Clear();
            });
            numbers = numbers.OrderByDescending(x => x.favorite).ThenByDescending(x => x.logmessages).ThenBy(x => x.status == "Online" ? 0 : x.status == "Offline" ? 1 : 2).ThenBy(x => x.locale).ToList();
            foreach (Number number in numbers) cbNumbersList.Invoke((MethodInvoker)delegate { cbNumbersList.Items.Add($"{(number.favorite ? "★ " : "")}{(number.logmessages ? "⏺ " : "")}{number.locale.ToUpper()} | +{number.number} | {number.status.ToUpper()}"); });
            if (cbNumbersList.Items.Count > 0) cbNumbersList.Invoke((MethodInvoker)delegate { cbNumbersList.SelectedIndex = 0; });

            // reselect number
            if (selectedNumber != "")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i].number == selectedNumber)
                    {
                        cbNumbersList.Invoke((MethodInvoker)delegate { cbNumbersList.SelectedIndex = i; });
                        break;
                    }
                }
            }

            // save to numbers.json
            quackr_wrapper.saveNumbers(numbers);
        }

        private void cbNumbersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNumbersList.SelectedIndex < 0 || cbNumbersList.SelectedIndex >= numbers.Count) return;
            selectedToolStripMenuItem.Enabled = true;
            lvMessages.Items.Clear();
            lvMessages.Items.Add(new ListViewItem(new string[] { "Loading...", "", "" }));
            quackr_wrapper.requestMessages(numbers[cbNumbersList.SelectedIndex].number);
            favoriteToolStripMenuItem.Checked = numbers[cbNumbersList.SelectedIndex].favorite;
            logMessagesToolStripMenuItem.Checked = numbers[cbNumbersList.SelectedIndex].logmessages;
        }

        private void byAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Number> newnumbers = quackr_wrapper.fetchNumbers();
                foreach (Number number in newnumbers)
                {
                    bool exists = false;
                    foreach (Number number2 in numbers)
                    {
                        if (number.number == number2.number)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists) numbers.Add(number);
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to fetch numbers.\n\n" + ex.Message, "TempPhone", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            LoadNumbers();
        }

        private void byNumbersjsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Number> newnumbers = quackr_wrapper.loadNumbers();
                foreach (Number number in newnumbers)
                {
                    bool exists = false;
                    foreach (Number number2 in numbers)
                    {
                        if (number.number == number2.number)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists) numbers.Add(number);
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load numbers.\n\n" + ex.Message, "TempPhone", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            LoadNumbers();
        }
        private void favoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbNumbersList.SelectedIndex < 0 || cbNumbersList.SelectedIndex >= numbers.Count) return;
            numbers[cbNumbersList.SelectedIndex].favorite = !numbers[cbNumbersList.SelectedIndex].favorite;
            LoadNumbers();
        }

        private void logMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbNumbersList.SelectedIndex < 0 || cbNumbersList.SelectedIndex >= numbers.Count) return;
            numbers[cbNumbersList.SelectedIndex].logmessages = !numbers[cbNumbersList.SelectedIndex].logmessages;
            LoadNumbers();
        }

        private void copyNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbNumbersList.SelectedIndex < 0 || cbNumbersList.SelectedIndex >= numbers.Count) return;
            Clipboard.SetText(numbers[cbNumbersList.SelectedIndex].number);
        }

        private void MessageLoggerThread()
        {
            while (true)
            {
                foreach (var number in numbers)
                    if (number.logmessages)
                        quackr_wrapper.requestMessages(number.number);

                Thread.Sleep(settings.refreshinterval * 1000);
            }
        }

        private void TempPhone_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void TempPhone_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                trayIcon.Visible = false;
                quackr_wrapper.saveNumbers(numbers);
                Environment.Exit(0);
            }
            catch { Environment.Exit(400); }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copySenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMessages.SelectedItems.Count > 0)
                Clipboard.SetText(lvMessages.SelectedItems[0].SubItems[1].Text);
        }

        private void copyMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMessages.SelectedItems.Count > 0)
                Clipboard.SetText(lvMessages.SelectedItems[0].SubItems[2].Text);
        }

        private void lvMessages_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvMessages.FocusedItem != null && lvMessages.FocusedItem.Bounds.Contains(e.Location))
                copyMenu.Show(Cursor.Position);
        }

        private void cbRefreshInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.refreshinterval = int.Parse(cbRefreshInterval.Text.Split(' ')[0]);
            settings.Save();
        }

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.startWithWindows = !settings.startWithWindows;
            settings.Save();

            if (settings.startWithWindows)
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue("TempPhone", Application.ExecutablePath);
                startMinimizedToolStripMenuItem.Enabled = true;
            }
            else
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.DeleteValue("TempPhone", false);
                startMinimizedToolStripMenuItem.Enabled = false;
            }
        }

        private void startMinimizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.startMinimized = !settings.startMinimized;
            settings.Save();
        }
    }
}