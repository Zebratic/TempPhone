using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TempPhone
{
    public class Number
    {
        public string locale { get; set; } = "";
        public string status { get; set; } = "";
        public string number { get; set; } = "";

        public List<Message> messages { get; set; } = new List<Message>();
        public bool favorite { get; set; } = false;
        public bool logmessages { get; set; } = false;
    }

    public class Message
    {
        public string locale { get; set; } = "";
        public string message { get; set; } = "";
        public string recipient { get; set; } = "";
        public string sender { get; set; } = "";
        public Int64 timestamp { get; set; } = 0;
        /*
            locale: "dk"
            message: "Doh, you already have a profile attached to this number and we currently only allow one profile per mobile number."
            recipient: "4520381900"
            sender: "*******0146"
            timestamp: 1688171698586
        */
    }
}