using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 招标书 类
    /// </summary>
    public class Tender:Base
    {
        public int TTId { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }


        public string Title { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// 招标地点
        /// </summary>
        public string TenderArea { get; set; }

        /// <summary>
        /// 招标开始时间
        /// </summary>
        public DateTime TenderStartDate { get; set; }


        /// <summary>
        /// 招标结束时间
        /// </summary>
        public DateTime TenderEndDate { get; set; }

        /// <summary>
        /// 标书发售地址
        /// </summary>
        public string TenderSalesAddress { get; set; }


        /// <summary>
        /// 招标委托机构
        /// </summary>
        public string TenderInvokeOrganization { get; set; }


        /// <summary>
        /// 详细说明
        /// </summary>
        public string DetailsDescript { get; set; }

    }
}
