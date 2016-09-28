using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStoreImg
    {
        int AddStoreImg(StoreImg img);

        List<StoreImg> GetStoreImg(int sID);
    }
}
