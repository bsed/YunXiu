using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace YunXiu.Model
{

    public class Product : Base
    {
        #region 属性
        /// <summary>
        /// 商品ID
        /// </summary>
        public int PID { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string Psn { get; set; } = "";

        /// <summary>
        ///分类
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// 店铺
        /// </summary>
        public Store Store { get; set; }

        /// <summary>
        /// 店铺配送模板ID
        /// </summary>
        public int StoreStID { get; set; }

        /// <summary>
        /// sku组ID
        /// </summary>
        public int SkuGID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 商城价
        /// </summary>
        public decimal ShopPrice { get; set; }

        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 状态 -1为下架
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 是否是精品
        /// </summary>
        public bool IsBest { get; set; }

        /// <summary>
        /// 是否是热销
        /// </summary>
        public bool IsHot { get; set; }

        /// <summary>
        /// 是否是新品
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 是否是推荐产品
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// 主图
        /// </summary>
        public string ShowImg { get; set; } = "";

        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleCount { get; set; }

        /// <summary>
        /// 访问数量
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        /// 收藏数量
        /// </summary>
        public int FavoriteCount { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = "";
        /// <summary>
        /// 官方说明
        /// </summary>
        public string OfficialGuarantee { get; set; } = "";
        /// <summary>
        /// 常见问题
        /// </summary>
        public string FAQs { get; set; } = "";

        /// <summary>
        /// 一颗星
        /// </summary>
        public int OneStar { get; set; }

        /// <summary>
        /// 两颗星
        /// </summary>
        public int TwoStar { get; set; }

        /// <summary>
        /// 三颗星 
        /// </summary>
        public int ThreeStar { get; set; }

        /// <summary>
        /// 四颗星
        /// </summary>
        public int FourStar { get; set; }

        /// <summary>
        /// 五颗星
        /// </summary>
        public int FiveStar { get; set; }

        public List<ProductAttr> Attributes { get; set; }
        #endregion
    }
}
