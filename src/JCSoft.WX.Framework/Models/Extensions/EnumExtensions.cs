using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework
{
    public static class EnumExtensions
    {
        public static string ToInt32String(this Enum obj)
        {
            if (obj != null)
            {
                return (Convert.ToInt32(obj)).ToString();
            }

            return String.Empty;
        }
    }
}
