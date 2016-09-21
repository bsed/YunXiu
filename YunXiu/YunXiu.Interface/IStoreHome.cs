using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStoreHome
    {
        bool AddStoreHome(StoreHome home);

        StoreHome GetStoreHomeByStore(int sID);
    }
}
