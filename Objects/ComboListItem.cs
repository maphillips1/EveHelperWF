using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{

    public class ComboListItem
    {
        public ComboListItem() 
        {
            this.key = 0;
            this.value = "";
        }
        public ComboListItem(int key, string value)
        {
            this.key = key;
            this.value = value;
        }
        public int key { get; set; }
        public string value { get; set; }
    }
}
