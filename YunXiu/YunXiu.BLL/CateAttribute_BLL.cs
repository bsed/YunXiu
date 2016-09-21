using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.DAL;
using YunXiu.Interface;
using YunXiu.Model;

namespace YunXiu.BLL
{
    public class CateAttribute_BLL : ICateAttribute
    {
        CateAttribute_DAL dal = new CateAttribute_DAL();
        public bool AddCateAttribute(CateAttribute ca)
        {
            return dal.AddCateAttribute(ca);
        }

        public bool DeleteCateAttribute(int caID)
        {
            return dal.DeleteCateAttribute(caID);
        }

        public List<CateAttribute> GetCateAttribute()
        {
            return dal.GetCateAttribute();
        }

        public List<CateAttribute> GetCateAttributeByCate(int cateID)
        {
            return dal.GetCateAttributeByCate(cateID);
        }
    }
}
