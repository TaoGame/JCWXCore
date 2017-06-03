using JCSoft.WX.Framework.Models.Requests;
using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Request.Requests
{
    public class RequestOrderEventMessage : RequestEventMessage
    {
        public RequestOrderEventMessage(XElement xml)
            : base(xml)
        {
            OrderId = xml.Element("OrderId").Value;
            OrderStatus = int.Parse(xml.Element("OrderStatus").Value);
            ProductId = xml.Element("ProductId").Value;
            SkuInfo = xml.Element("SkuInfo").Value;
        }

        public string OrderId { get; set; }

        public int OrderStatus { get; set; }

        public string ProductId { get; set; }

        public string SkuInfo { get; set; }
    }
}
