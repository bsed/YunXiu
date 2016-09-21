using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IProductStorage
    {
        /// <summary>
        /// 产品入库
        /// </summary>
        /// <param name="productStorage">入库信息</param>
        /// <returns>入库是否成功</returns>
        bool AddProductStorage(ProductStorage productStorage);
    }
}
