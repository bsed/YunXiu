using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IStoreDynamics
    {
        bool AddStoreDynamics(StoreDynamics dynamics);

        bool DeleteStoreDynamics(int dID);

        bool UpdateStoreDynamics(StoreDynamics dynamics);

        List<StoreDynamics> GetStoreDynamics(int sID);
    }
}
