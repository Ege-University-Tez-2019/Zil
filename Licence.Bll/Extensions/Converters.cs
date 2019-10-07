using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licence.Bll.Extensions
{
    public static class Converters
    {
        public static int toInt32(this object val)
        {
            return Convert.ToInt32(val);
        }
        public static decimal toDecimal(this object val)
        {
            return Convert.ToDecimal(val);
        }
        public static byte toByte(this object val)
        {
            return Convert.ToByte(val);
        }
        public static ushort toUshort(this string val)
        {
            return ushort.Parse(val);
        }
        public static double toDouble(this object val)
        {
            return Convert.ToDouble(val);
        }
        public static DateTime ToDateTime(this object val)
        {
            return Convert.ToDateTime(val);
        }
        public static bool HasProperty(this ExpandoObject value, string property)
        {
            bool hasProp = false;
            if (((IDictionary<String, object>)value).ContainsKey(property))
            {
                hasProp = true;
            }
            return hasProp;
        }

        public static T Get<T>(this ExpandoObject value, string property)
        {
            return (T)((IDictionary<String, dynamic>)value)[property];
        }
    }
}
