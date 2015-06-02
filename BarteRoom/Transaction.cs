using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Transaction
    {
        private string type;
        private string comments;
        private string user;
        private string item_id;
        private string transaction_id;
        private LinkedList<string> offerdItemsList;
        public Transaction(string user, string type, string item_id, LinkedList<string> offerdItemsList, string comments)
        {
            this.comments = comments;
            this.user = user;
            this.type = type;
            this.item_id = item_id;
            this.offerdItemsList = offerdItemsList;
            Guid newGuid = Guid.NewGuid();
            this.transaction_id = newGuid.ToString(); ;

        }
        public String getComments()
        {
            return this.comments;
        }
        public String getUser()
        {
            return this.user;
        }
        public String getType()
        {
            return this.type;
        }
        public String getItem_id()
        {
            return this.item_id;
        }
        public String getTransaction_id()
        {
            return this.transaction_id;
        }
        public LinkedList<string> getOfferdItemsList()
        {
            return this.offerdItemsList;
        }
    }
}