using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunXiu.Commom;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cText = Security.MD5Encrypt("123456789");
            Console.WriteLine(cText);
        }
    }
}
