using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 店铺等级表
    /// </summary>
    public class Storeranks
    {
        /// <summary>
        /// 店铺等级ID
        /// </summary>
        public int storerid {get;set;}

        /// <summary>
        /// 店铺等级名称
        /// </summary>
        public string title {get;set;}

        /// <summary>
        /// 头像
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// 诚信下限
        /// </summary>
        public int honestieslower {get;set;}

        /// <summary>
        /// 诚信上限
        /// </summary>
        public int honestiesupper {get;set;}

        /// <summary>
        /// 商品数量
        /// </summary>
        public int productcount{get;set;}
    }
}
