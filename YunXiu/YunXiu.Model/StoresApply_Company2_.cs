using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 企业店铺入驻第二步 表
    /// </summary>
    public class StoresApply_Company2_
    {
        public int Id {get;set;}

        /// <summary>
        /// 法定代表人姓名
        /// </summary>
        public int LegalName {get;set;}

        /// <summary>
        /// 法定代表人身份证号码
        /// </summary>
        public int LegalIDCard {get;set;}

        /// <summary>
        /// 营业执照副本电子版
        /// </summary>
        public int Certificate_Pho {get;set;}

        /// <summary>
        /// 机构代码证电子版
        /// </summary>
        public int OrganizeCodePho {get;set;}

        /// <summary>
        /// 法定人联系电话
        /// </summary>
        public int LegalPhone {get;set;}

        /// <summary>
        /// 纳税人识别号
        /// </summary>
        public int TaxPayerCode {get;set;}

        /// <summary>
        /// 纳税人类型
        /// </summary>
        public int TaxPayerType {get;set;}

        /// <summary>
        /// 纳税类型税码
        /// </summary>
        public int TaxCode {get;set;}

        /// <summary>
        /// 税务登记电子版
        /// </summary>
        public int TaxRedgionPho {get;set;}

        /// <summary>
        /// 纳税人资格证电子版
        /// </summary>
        public int TaxPayerPermissionPho {get;set;}

        /// <summary>
        /// 公司银行卡开户名
        /// </summary>
        public int BankPickerName {get;set;}

        /// <summary>
        /// 公司银行卡账号
        /// </summary>
        public int BankCard {get;set;}

        /// <summary>
        /// 开户银行支行名称
        /// </summary>
        public int BankName {get;set;}

        /// <summary>
        /// 开户银行支行联行号
        /// </summary>
        public int BankCode {get;set;}

        /// <summary>
        /// 开户银行支行所在地区ID
        /// </summary>
        public int BankLoctionRegion {get;set;}

        /// <summary>
        /// 开户许可证电子版
        /// </summary>
        public int AccountPerimssionPho {get;set;}

        /// <summary>
        /// 对应企业入驻第一步中的ApplyId
        /// </summary>
        public int ApplyId {get;set;}

        /// <summary>
        /// 身份证正面
        /// </summary>
        public int IDCardPhoForwardPath {get;set;}

        /// <summary>
        /// 身份证反面
        /// </summary>
        public int IDCardPhoBackPath {get;set;}

        /// <summary>
        /// 手持身份证
        /// </summary>
        public int IDCardInHandPath{get;set;}
    }
}
