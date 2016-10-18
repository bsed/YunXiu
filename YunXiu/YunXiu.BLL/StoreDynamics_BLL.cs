using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;
using YunXiu.DAL;
using YunXiu.Interface;

namespace YunXiu.BLL
{
    public class StoreDynamics_BLL:IStoreDynamics
    {
        StoreDynamics_DAL dal = new StoreDynamics_DAL();

        public bool AddStoreDynamics(StoreDynamics dynamics)
        {
            return dal.AddStoreDynamics(dynamics);
        }

        public bool DeleteStoreDynamics(int dID)
        {
            return dal.DeleteStoreDynamics(dID);
        }

        public List<StoreDynamics> GetStoreDynamics(int sID)
        {
            return dal.GetStoreDynamics(sID);
        }

        public bool UpdateStoreDynamics(StoreDynamics dynamics)
        {
            return dal.UpdateStoreDynamics(dynamics);
        }
    }
}
