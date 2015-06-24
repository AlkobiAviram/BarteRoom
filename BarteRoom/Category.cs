using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Category
    {
        private string main_categoty;
        private string sub_categoty;
        private int id;
        public Category(string main_categoty, string sub_categoty,int id)
        {
            this.main_categoty = main_categoty;
            this.sub_categoty = sub_categoty;
            this.id = id;
        }
        public string Main_categoty
        {
            get { return this.main_categoty; }
            set { this.main_categoty = value; }
        }
        public string Sub_categoty
        {
            get { return this.sub_categoty; }
            set { this.sub_categoty = value; }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}