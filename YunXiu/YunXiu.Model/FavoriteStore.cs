using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class FavoriteStore
    {
        public int RecordId { get; set; }

        public int Uid { get; set; }

        public int StoreId { get; set; }

        public DateTime AddTime { get; set; }

        public string SName { get; set; }

        public string Logo { get; set; }
    }
}
