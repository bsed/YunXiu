using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 采购计划表
    /// </summary>
    public class PurchasePlan:Base
    {
        /// <summary>
        /// 表ID
        /// </summary>
        public int PPId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 采购商品名
        /// </summary>
        public string PName { get; set; }


        /// <summary>
        /// 采购详细说明
        /// </summary>
        public string PurchaseDetails { get; set; }


        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 希望单价
        /// </summary>
        public decimal HopePrice { get; set; }

        /// <summary>
        /// 采购商
        /// </summary>
        public string PurchaseName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContantName { get; set; }

        /// <summary>
        /// 联系方式，可填写：电话，手机，邮箱之类
        /// </summary>
        public string ContantWay { get; set; }

        /// <summary>
        /// 采购截止日期
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        public Category PurchaseType { get; set; }

        /// <summary>
        /// 对供应商区域要求
        /// </summary>
        public string RequestManufactureArea { get; set; }

        /// <summary>
        /// 收货地要求
        /// </summary>
        public string RequestReceiveArea { get; set; }

        /// <summary>
        /// 联系方式的要求（允许以任何方式联系我，只允许网上留言）
        /// 具体说明见需求
        /// </summary>
        public string RequestContant { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

    }
}
