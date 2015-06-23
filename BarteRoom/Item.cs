using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Item
    {
        private String usr;
        private String name;
        private String clss;
        private String comments;
        private String description;
        private String id;
        private String sub_clss;
        public Item()
        {
            Guid newGuid = Guid.NewGuid();
            this.id = newGuid.ToString(); 
        }
        public Item(String usr, String name, String clss, String comments, String description)
        {
            this.usr = usr;
            this.name = name;
            this.clss = clss;
            this.comments = comments;
            this.description = description;
            Guid newGuid = Guid.NewGuid();
            this.id = newGuid.ToString();
            this.sub_clss = sub_clss;
        }
        public string Clss
        {
            get { return this.clss; }
            set { this.clss= value; }
        }
        public string Usr
        {
            get { return this.usr; }
            set { this.usr = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name= value; }
        }
        public string Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Sub_clss
        {
            get { return this.sub_clss; }
            set { this.sub_clss = value; }
        }
    }
}