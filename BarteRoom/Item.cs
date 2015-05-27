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
        private Byte[] pic_name;

        public Item(String usr, String name, String clss, String comments, String description, Byte[] pic_name)
        {
            this.usr = usr;
            this.name = name;
            this.clss = clss;
            this.comments = comments;
            this.description = description;
            this.pic_name = pic_name;
        }

    }
}