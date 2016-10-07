using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Interface
{
    public interface ISMS
    {
        bool Send(List<string> phones,string content);
    }
}
