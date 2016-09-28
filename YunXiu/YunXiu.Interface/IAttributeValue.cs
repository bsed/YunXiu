using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Model;

namespace YunXiu.Interface
{
    public interface IAttributeValue
    {
        bool AddAttributeValue(AttributeValue av);

        bool UpdateAttributeValue(AttributeValue av);

        bool DeleteAttributeValue(int avID);

        List<AttributeValue> GetAttributeValue(List<int> attrID);
    }
}
