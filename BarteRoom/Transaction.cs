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

        public String Comments
        {
           get { return this.comments;}
            set {this.comments=value;}
        }
        public String Bidder
        {
            get { return this.bidder;}
            set {this.bidder=value;}
        }
        public String Owner
        {
            get { return this.owner;}
            set {this.owner=value;}
        }
        public String Item_id
        {
            get { return this.item_id;}
            set {this.item_id=value;}
        }
        public String Transaction_id
        {
            get { return this.transaction_id;}
            set {this.transaction_id=value;}
        }
        public int ReadBid
        {
            get { return this.readBid;}
            set { this.readBid = value; }
        }
        public LinkedList<string> OfferdItemsList
        {
            get { return this.offerdItemsList; }
            set { this.offerdItemsList = value; }
        }
  
    }
}