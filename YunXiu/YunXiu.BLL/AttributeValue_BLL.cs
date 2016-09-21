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
    class AttributeValue_BLL : IAttributeValue
    {
        AttributeValue_DAL dal = new AttributeValue_DAL();
        public bool AddAttributeValue(AttributeValue av)
        {
            return dal.AddAttributeValue(av);
        }

        public bool DeleteAttributeValue(int avID)
        {
            return dal.DeleteAttributeValue(avID);
        }

        public bool UpdateAttributeValue(AttributeValue av)
        {
            return dal.UpdateAttributeValue(av);
        }
    }
}
