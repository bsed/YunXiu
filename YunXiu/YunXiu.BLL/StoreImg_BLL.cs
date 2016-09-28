using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.Interface;
using YunXiu.DAL;

namespace YunXiu.BLL
{
    public class StoreImg_BLL : IStoreImg
    {
        StoreImg_DAL dal = new StoreImg_DAL();
        public int AddStoreImg(StoreImg img)
        {
            return dal.AddStoreImg(img);
        }

        public List<StoreImg> GetStoreImg(int sID)
        {
            return dal.GetStoreImg(sID);
        }
    }
}
