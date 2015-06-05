using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarteRoom
{
    public class Image
    {
        private string id;
        private string path;
        public Image(string id, string path)
        {
            this.id = id;
            this.path = path;
        }
        public string getId(){
            return this.id;
        }
        public string getPath()
        {
            return this.path;
        }
    }
}