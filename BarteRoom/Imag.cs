using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Imag
    {
        private string item_id;
        private string path;
        private string image_id;
        private int isProfile;
        public Imag(string item_id, string path,int isProfile)
        {
            this.item_id = item_id;
            this.path = path;
            Guid newGuid = Guid.NewGuid();
            this.image_id = newGuid.ToString();
            this.isProfile = isProfile;

        }
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }
        public string Item_id
        {
            get { return this.item_id; }
            set { this.item_id = value; }
        }
        public string Image_id
        {
            get { return this.image_id; }
            set { this.image_id = value; }
        }
        public int IsProfile
        {
            get { return this.isProfile; }
            set { this.isProfile = value; }
        }
    }
}