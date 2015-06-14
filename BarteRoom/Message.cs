using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Message
    {
        private string id,from,to,subject,msg_body;

        public Message(string from, string to, string subject, string msg_body)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.msg_body = msg_body;
            Guid newGuid = Guid.NewGuid();
            this.id = newGuid.ToString(); ;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string From
        {
            get { return from; }
            set { from = value; }
        }

        public string To
        {
            get { return to; }
            set { to = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Msg_body
        {
            get { return msg_body; }
            set { msg_body = value; }
        }
   
    }
}