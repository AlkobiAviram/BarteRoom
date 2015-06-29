using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{

    public class Match
    {
        private string bidded_item;
        private string usr;
        private string date;
        private string offered_item;
        public Match(string usr, string bidded_item, string offered_item)
        {
        this.bidded_item=bidded_item;
        this.usr=usr;
        this.offered_item=offered_item;
        DateTime dt = DateTime.Now;
        this.date = Logic.changeDateFormat(dt.ToString());
        }
        public string Bidded_item
        {
        get{return this.bidded_item;}
        set{this.bidded_item=value;}
        }
        public string Usr
        {
            get { return this.usr; }
            set { this.usr = value; }
        }
        public string Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        public string Offered_item
        {
            get { return this.offered_item; }
            set { this.offered_item = value; }
        }
    
    }
}