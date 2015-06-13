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
        public string getId()
        {
            return this.id;
        }
        public string getFrom()
        {
            return this.from;
        }
        public string getTo()
        {
            return this.to;
        }
        public string getSubject()
        {
            return this.subject;
        }
        public string getMsg_body()
        {
            return this.msg_body;
        }
        public void setId(string newId)
        {
            this.id=newId;
            return;
        }
   
    }
}