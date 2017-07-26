using System.Xml.Linq;

namespace FrameworkCoreTest
{
    internal class MiddleMessage
    {
        private XElement xElement;

        public MiddleMessage(XElement xElement)
        {
            this.xElement = xElement;
        }
    }
}