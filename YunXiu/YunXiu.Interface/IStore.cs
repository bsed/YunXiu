using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStore
    {
        decimal GetStoreAmount(int sID);

        bool AddStore(Store store);

        bool UpdateStore(Store store);

        bool DeleteStore(int sID);
    }
}
