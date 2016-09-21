using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 退换货表
    /// </summary>
    public class RefundProducts
    {

        public int RefundProductId { get; set; }

        public int Uid { get; set; }
        public int Pid { get; set; }
        public int Storeid { get; set; }
        public int state { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int Oid { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime applytime { get; set; }

        /// <summary>
        /// 申请备注
        /// </summary>
        public string ApplyRemark { get; set; }

        /// <summary>
        /// 申请理由
        /// </summary>
        public string ApplyReason { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal Refundmoney { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string ResultRemark { get; set; }

        /// <summary>
        /// 退款编号
        /// </summary>
        public string refundsn { get; set; }

        /// <summary>
        /// 退款方式名称
        /// </summary>
        public string refundsystemname { get; set; }

        /// <summary>
        /// 退款方式 好友名
        /// </summary>
        public string refundfriendname { get; set; }

        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime refundtime { get; set; }

        /// <summary>
        /// 支付单号
        /// </summary>
        public string paysn { get; set; }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string paysystemname { get; set; }

        /// <summary>
        /// 支付方式 好友名
        /// </summary>
        public string payfriendname { get; set; }

        /// <summary>
        /// 退货物流名称
        /// </summary>
        public string ReturnLogisticsName { get; set; }

        /// <summary>
        /// 退货物流单号
        /// </summary>
        public string LogisticsNo { get; set; }

        /// <summary>
        /// 物流收件时间
        /// </summary>
        public DateTime LogisticeTime { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Phos { get; set; }
    }
}
