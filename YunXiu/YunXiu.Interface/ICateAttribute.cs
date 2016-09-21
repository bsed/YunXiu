using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface ICateAttribute
    {
        bool AddCateAttribute(CateAttribute ca);

        List<CateAttribute> GetCateAttributeByCate(int cateID);

        List<CateAttribute> GetCateAttribute();

        bool DeleteCateAttribute(int caID);
    }
}
