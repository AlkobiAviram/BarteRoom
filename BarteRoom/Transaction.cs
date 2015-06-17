using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Transaction
    {
        private string transaction_id;
        private string item_id;
        private string owner;
        private string bidder;
        private string comments;
        private int readBid;
        private string date;
        private LinkedList<string> offerdItemsList;
        public Transaction(string item_id, string owner, string bidder, LinkedList<string> offerdItemsList, string comments)
        {
            this.item_id=item_id;
            this.owner=owner;
            this.bidder=bidder;
            this.comments=comments;
            this.readBid=0;

            this.offerdItemsList = offerdItemsList;
            Guid newGuid = Guid.NewGuid();
            this.transaction_id = newGuid.ToString();


            DateTime dt = DateTime.Now;
            this.date = Logic.changeDateFormat(dt.ToString());
        }
        public string Date 
        {
            get { return this.date;}
            set {this.date=value;}

        }

        public String getComments()
        {
            return this.comments;
        }
        public String getBidder()
        {
            return this.bidder;
        }
        public String getOwner()
        {
            return this.owner;
        }
        public String getItem_id()
        {
            return this.item_id;
        }
        public String getTransaction_id()
        {
            return this.transaction_id;
        }
        public void setTransaction_id(string newId)
        {
             this.transaction_id=newId;
             return;
        }
        public void setReadBid(int newReadBid)
        {
            this.readBid= newReadBid;
            return;
        }
        public LinkedList<string> getOfferdItemsList()
        {
            return this.offerdItemsList;
        }
        public int getReadBid()
        {
            return this.readBid;
        }
    }
}