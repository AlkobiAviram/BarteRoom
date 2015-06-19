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
        public int getIsProfile()
        {
            return this.isProfile;
        }
        public void setImage_id(int new_bool)
        {
            this.isProfile= new_bool;
        }


        public string getImage_id(){
            return this.image_id;
        }
        public void setImage_id(string new_id)
        {
            this.image_id=new_id;
        }
        public string getItem_id()
        {
            return this.item_id;
        }
        public string getPath()
        {
            return this.path;
        }
    }
}