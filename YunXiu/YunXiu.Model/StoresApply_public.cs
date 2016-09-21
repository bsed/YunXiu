using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 普通申请入驻表
    /// </summary>
    public class StoresApply_public
    {
        /// <summary>
        /// 申请ID
        /// </summary>
        public int ApplyId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string StroeName { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        public int RegionsId { get; set; }

        /// <summary>
        /// 店铺地址
        /// </summary>
        public string StoreAddress { get; set; }

        /// <summary>
        /// LOGO
        /// </summary>
        public string LogPath { get; set; }

        /// <summary>
        /// 店铺简介
        /// </summary>
        public string Store_Introduce { get; set; }

        /// <summary>
        /// 店铺类型，对应TipFlexTable_storeindustries表的数据
        /// </summary>
        public int Store_Type_Id { get; set; }

        /// <summary>
        /// 店主真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 身份证正面图片
        /// </summary>
        public string IDCardPhoForwardPath { get; set; }

        /// <summary>
        /// 身份证反面图片
        /// </summary>
        public string IDCardPhoBackPath { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 手持身份证照片
        /// </summary>
        public string IDCardInHandPath { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LastUpdateUserId { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public string ReturnRemark { get; set; }		
    }
}
