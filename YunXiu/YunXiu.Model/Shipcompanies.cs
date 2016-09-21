using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Model
{
    /// <summary>
    /// 配送公司表
    /// </summary>
    public class Shipcompanies
    {
        /// <summary>
        /// 配送公司ID
        /// </summary>
        public int shipcoid {get;set;}
        public string name {get;set;}
        public string displayorder { get; set; }
    }
}
