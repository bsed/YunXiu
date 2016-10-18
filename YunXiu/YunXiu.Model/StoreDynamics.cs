using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class StoreDynamics : Base
    {
        public int DID { get; set; }

        public Store Store { get; set; }

        public string Title { get; set; }

        public string DContent { get; set; }
    }
}
