using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺表
    /// </summary>
    public class Store : Base
    {
        public int StoreID { get; set; }

        /// <summary>
        /// 店长
        /// </summary>
        public User StoreManager { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// 店铺等级ID
        /// </summary>
        public int StorerID { get; set; }

        /// <summary>
        /// 店铺行业ID
        /// </summary>
        public Category Category { get; set; }

        public string Logo { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string QQ { get; set; }

        /// <summary>
        /// 商品描述评分
        /// </summary>
        public decimal DePoint { get; set; }

        /// <summary>
        /// 商家服务评分
        /// </summary>
        public decimal SePoint { get; set; }

        /// <summary>
        /// 配送评分
        /// </summary>
        public decimal ShPoint { get; set; }

        /// <summary>
        /// 诚信度
        /// --原DB为INT 现修改成decimal
        /// </summary>
        public decimal Honesties { get; set; }

        /// <summary>
        /// 店铺有效期
        /// </summary>
        public DateTime ValidityDate { get; set; }


        public string Theme { get; set; }

        /// <summary>
        /// 公告
        /// </summary>
        public string Announcement { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 店铺资金
        /// </summary>
        public decimal StoreMoney { get; set; }

        /// <summary>
        /// 店铺链接
        /// </summary>
        public string StoreLink { get; set; }
    }
}
