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
        private byte[] pic_name;
        private String id;
        public Item(String usr, String name, String clss, String comments, String description, Byte[] pic_name)
        {
            this.usr = usr;
            this.name = name;
            this.clss = clss;
            this.comments = comments;
            this.description = description;
            this.pic_name = pic_name;
            Guid newGuid = Guid.NewGuid();
            this.id = newGuid.ToString(); ;
        }
        public String getUsr()
        {
            return this.usr;
        }
        public String getName()
        {
            return this.name;
        }
        public String getClass()
        {
            return this.clss;
        }
        public String getComments()
        {
            return this.comments;
        }
        public String getDescription()
        {
            return this.description;
        }
        public byte[] getPic()
        {
            return this.pic_name;
        }
        public String getId()
        {
            return this.id;
        }
    }
}