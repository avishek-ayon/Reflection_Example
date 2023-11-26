using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public static class JsonFormatter
    {
        public static string Convert(object item)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");

            Type type = item.GetType();
            PropertyInfo[] propertiesInfo = type.GetProperties();
            int propertyLength = propertiesInfo.Length;
            int initialProperty = 0;

            foreach (PropertyInfo property in propertiesInfo)
            {
                object propertyValue = property.GetValue(item);
                Type propertyType = property.PropertyType;
            

                stringBuilder.Append($"\" { property.Name} \":");
                if (propertyType == typeof(int) || propertyType == typeof(double) || propertyType == typeof(float) || propertyType == typeof(decimal) || propertyType == typeof(sbyte) || propertyType == typeof(long) || propertyType == typeof(short) || propertyType == typeof(byte))
                {
                    stringBuilder.Append($"{propertyValue.ToString()}");
                }
                else if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime))
                {
                    stringBuilder.Append($"\" {propertyValue.ToString()} \"");
                }
                else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    stringBuilder.Append("[");
                    IEnumerable enumerable = (IEnumerable)propertyValue;
                    int currentItem = 0;
                    int itemCount = enumerable.Cast<object>().Count();

                    foreach (object prop in enumerable)
                    {
                        stringBuilder.Append(Convert(prop));
                        if (currentItem < itemCount - 1)
                        {
                            stringBuilder.Append(",");
                        }
                        currentItem++;
                    }

                    stringBuilder.Append("]");
                }
                else
                {
                    stringBuilder.Append(Convert(propertyValue));
                }

                if (initialProperty < propertyLength - 1)
                {
                    stringBuilder.Append(",");
                }
                initialProperty++;
            }

            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}
