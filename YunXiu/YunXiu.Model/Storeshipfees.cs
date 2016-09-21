using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺配送费用表
    /// 根据地区来区分费用
    /// </summary>
    public class Storeshipfees
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public int recordid { get; set; }

        /// <summary>
        /// 店铺配送模板ID
        /// </summary>
        public int storestid { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        public int regionid { get; set; }

        /// <summary>
        /// 起步值
        /// </summary>
        public int startvalue { get; set; }

        /// <summary>
        /// 起步费用
        /// </summary>
        public int startfee { get; set; }

        /// <summary>
        /// 添加值
        /// </summary>
        public int addvalue { get; set; }

        /// <summary>
        /// 添加费用
        /// </summary>
        public int addfee { get; set; }
    }
}
