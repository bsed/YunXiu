using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YunXiu.Commom
{
    public class Utilities
    {
        /// <summary>
        /// 集合转换成字符串类型
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListToListStr(List<int> list)
        {
            var str = "";
            list.ForEach(s => str += s + ",");
            str = str.Substring(0, str.Length - 1);
            return str;
        }

        /// <summary>
        /// 获取类的字段名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> expr)
        {
            var rtn = "";
            if (expr.Body is UnaryExpression)
            {
                rtn = ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression)
            {
                rtn = ((MemberExpression)expr.Body).Member.Name;
            }
            else if (expr.Body is ParameterExpression)
            {
                rtn = ((ParameterExpression)expr.Body).Type.Name;
            }
            return rtn;
        }

        public static object ConvertToT(string type,string val)
        {
            object o = null;
            try
            {
                switch (type.ToLower())
                {
                    case "int32":
                        o = Convert.ToInt32(val);
                        break;
                    case "string":
                        o = Convert.ToString(val);
                        break;
                    case "boolean":
                        o = Convert.ToBoolean(val);
                        break;
                    case "decimal":
                        o = Convert.ToDecimal(val);
                        break;
                }
            }
            catch(Exception ex)
            {

            }
            return o;
        }

        /// <summary>
        /// 判断整数是否是负数
        /// </summary>
        /// <param name="i">整数</param>
        /// <returns></returns>
        public static bool IntIsNegative(int i)
        {
            var result = false;
            if (i < 0) result = true;
            return result;
        }
    }
}
