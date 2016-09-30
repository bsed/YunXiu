using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    public class TFUser
    {
        /// <summary>
        /// 用户guid
        /// </summary>
        public Guid client_guid { get; set; }

        /// <summary>
        /// 用户名称，不同于登录名
        /// </summary>
        public string client_name { get; set; }

        /// <summary>
        /// 状态，”null/0“停用;“1”可用
        /// </summary>
        public bool status { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public Guid role_type { get; set; }

        /// <summary>
        /// 上次选择语言，null,默认，显示中文
        /// </summary>
        public Guid last_lcid { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string cellphone { get; set; }

        /// <summary>
        /// 座机号
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string zip { get; set; }

        /// <summary>
        /// 州/市/县
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string fax { get; set; }

        public string client_logo { get; set; }

        /// <summary>
        /// 证书编号,安全项*
        /// </summary>
        public string passport_no { get; set; }

        /// <summary>
        /// 证书类型,"null/0"身份证,"1"护照,安全项*
        /// </summary>
        public string passport_type { get; set; }

        /// <summary>
        /// 公司名称，不重复，role_type=1.不为Null
        /// </summary>
        public string company_name { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        public string contact_name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string contact_phone { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime create_date { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string truename { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string birthday { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string educatiol { get; set; }

        /// <summary>
        /// 学校
        /// </summary>
        public string school { get; set; }

        /// <summary>
        /// 婚姻状况,0未设置,1未婚,2已婚
        /// </summary>
        public string merriagestatus { get; set; }

        /// <summary>
        /// 公司行业
        /// </summary>
        public string businesstype { get; set; }

        /// <summary>
        /// 公司规模
        /// </summary>
        public string businessscale { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string userposition { get; set; }

        /// <summary>
        /// 密保问题枚举值
        /// </summary>
        public string question { get; set; }

        /// <summary>
        /// 密保答案
        /// </summary>
        public string answer { get; set; }

        /// <summary>
        /// 真是姓名认证状态,"0"否,"1"是
        /// </summary>
        public string realstatus { get; set; }

        /// <summary>
        /// 邮件认证状态,"0"否,"1"是
        /// </summary>
        public string emailstatus { get; set; }

        /// <summary>
        /// 注册
        /// </summary>
        public string questionstatus { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public string registertime { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public string logintimes { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string lastlogintime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string lastloginip { get; set; }

        /// <summary>
        /// 是否虚拟用户,"0"否,"1"是
        /// </summary>
        public string isvirtual { get; set; }

        /// <summary>
        /// 是否开放代理状态,"0"否,"1"是
        /// </summary>
        public string openagentstatus { get; set; }

        /// <summary>
        /// 是否公司代理,"0"否,"1"是
        /// </summary>
        public string iscompanyagent { get; set; }

        /// <summary>
        /// 创建代理时间
        /// </summary>
        public DateTime agentcreatetime { get; set; }

        /// <summary>
        /// 代理号,用于发展下线
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 开通系统状态
        /// </summary>
        public int systemstatus { get; set; }

        /// <summary>
        /// 权限所属组别
        /// </summary>
        public string group_code { get; set; }

        /// <summary>
        /// 是否管理员,"0"否,"1"是
        /// </summary>
        public bool isadmin { get; set; }
    }
}
