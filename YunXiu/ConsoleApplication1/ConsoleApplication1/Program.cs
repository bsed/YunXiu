using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Commom;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> listStr = new List<string>();
            listStr.Add("dddd");
            listStr.Add("ccccc");
            var id = Utilities.ListToListStr(listStr);
        }
    }
}
