using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 额外属性表
    /// </summary>
    public class ExtTable:Base
    {

        public int ExtId { get; set; }

        /// <summary>
        /// 关联的ID
        /// </summary>
        public int ContantId { get; set; }

        /// <summary>
        /// 关联的表名
        /// </summary>
        public string ContantTableName { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        public string ExtName { get; set; }


        /// <summary>
        /// 属性值
        /// </summary>
        public string ExtValue { get; set; }

        public int CreateUid { get; set; }

        public int LastUpdateUid { get; set; }

    }
}
