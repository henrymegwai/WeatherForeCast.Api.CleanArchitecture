using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string value) where T : struct
        {
            if (Enum.TryParse(value, out T result))
            {
                return result;
            }
            else
            {
                return default(T);
            }
        }
    }
}
