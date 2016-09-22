using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class FavoriteStore:Base
    {
        public int FID { get; set; }

        public User User { get; set; }

        public Store Store { get; set; }
    }
}
