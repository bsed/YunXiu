using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 单品促销活动表
    /// </summary>
    public class Singlepromotions
    {
       /// <summary>
       /// 促销活动ID
       /// </summary>
        public int pmid {get;set;}

        /// <summary>
        /// 商品ID
        /// </summary>
        public int pid {get;set;}

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int storeid {get;set;}

        /// <summary>
        /// 时间段1，开始时间
        /// </summary>
        public DateTime starttime1 {get;set;}

        /// <summary>
        /// 时间段1，结束时间
        /// </summary>
        public DateTime endtime1 { get; set; }

        /// <summary>
        /// 时间段2，开始时间
        /// </summary>
        public DateTime starttime2 { get; set; }

        /// <summary>
        /// 时间段2，结束时间
        /// </summary>
        public DateTime endtime2 { get; set; }

        /// <summary>
        /// 时间段3，开始时间
        /// </summary>
        public DateTime starttime3 { get; set; }

        /// <summary>
        /// 时间段3，结束时间
        /// </summary>
        public DateTime endtime3 { get; set; }

        /// <summary>
        /// 参与活动用户最低等级
        /// </summary>
        public int userranklower {get;set;}

        public int state {get;set;}

        public string name {get;set;}

        /// <summary>
        /// 广告语
        /// </summary>
        public string slogan { get; set; }

        /// <summary>
        /// 折扣类型（0：折扣，1：直降，2：扣后价）
        /// </summary>
        public int discounttype {get;set;}

        /// <summary>
        /// 折扣值
        /// </summary>
        public decimal discountvalue {get;set;}

        /// <summary>
        /// 赠送优惠卷类型ID
        /// 什么鬼？？？
        /// </summary>
        public int coupontypeid {get;set;}

        /// <summary>
        /// 支付积分
        /// </summary>
        public int paycredits {get;set;}

        /// <summary>
        /// 是否限制库存
        /// </summary>
        public int isstock {get;set;}

        /// <summary>
        /// 库存数量
        /// </summary>
        public int stock {get;set;}

        /// <summary>
        /// 配额下限
        /// </summary>
        public int quotalower {get;set;}

        /// <summary>
        /// 配额上限
        /// </summary>
        public int quotaupper {get;set;}

        /// <summary>
        /// 最大购买数量
        /// </summary>
        public int allowbuycount{get;set;}
    }
}
