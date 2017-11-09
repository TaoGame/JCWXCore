using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace JCSoft.WX
{
    public static class XmlElementExtensions
    {
        public static string GetValue(this XElement element)
        {
            if(element != null)
            {
                return element.Value;
            }

            return String.Empty;
        }
    }
}
