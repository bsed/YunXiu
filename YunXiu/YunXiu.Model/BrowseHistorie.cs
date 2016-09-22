using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class BrowseHistorie : Base
    {
        public int HID { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }
    }
}
