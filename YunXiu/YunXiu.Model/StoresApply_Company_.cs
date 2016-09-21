using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 企业店铺入驻第一步 表
    /// </summary>
    public class StoresApply_Company_
    {
        public int ApplyId { get; set; }

        public int Uid { get; set; }

        public int state { get; set; }

        /// <summary>
        /// 证书类型,0普通营业执照，1多证合一营业执照
        /// </summary>
        public int Certificate_Type { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 信用代码/注册号
        /// </summary>
        public string RegistCode { get; set; }

        /// <summary>
        /// 营业执照所在地区Id
        /// </summary>
        public int Certificate_RegionId { get; set; }

        /// <summary>
        /// 营业执照详细地址
        /// </summary>
        public string Certificate_Address { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        public string EstablishDate { get; set; }

        /// <summary>
        /// 营业期限
        /// </summary>
        public string BusinessTime { get; set; }

        /// <summary>
        /// 注册资本
        /// </summary>
        public decimal RegisteredCapital { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        public string Scope_Of_Business { get; set; }

        /// <summary>
        /// 公司所在地区ID
        /// </summary>
        public int CompanyRegion { get; set; }

        /// <summary>
        /// 公司详细地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// 公司紧急联系人
        /// </summary>
        public string CompanyContantName { get; set; }

        /// <summary>
        /// 公司紧急联系人手机
        /// </summary>
        public string CompanyContantPhone { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizeCode { get; set; }

        /// <summary>
        /// 机构代码证有效期
        /// </summary>
        public string OrganizeDate { get; set; }

        public int CreateDate { get; set; }

        public int LastUpdate { get; set; }

        public int LastUpdateUserId { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public int ReturnRemark { get; set; }
    }
}
