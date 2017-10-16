using JCSoft.WX.Framework.Models.Requests;
using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Request.Requests
{
    public class RequestOrderEventMessage : RequestEventMessage
    {
        public RequestOrderEventMessage(XElement xml)
            : base(xml)
        {
            OrderId = xml.Element("OrderId").GetValue();
            OrderStatus = int.Parse(xml.Element("OrderStatus").GetValue());
            ProductId = xml.Element("ProductId").GetValue();
            SkuInfo = xml.Element("SkuInfo").GetValue();
        }

        public string OrderId { get; set; }

        public int OrderStatus { get; set; }

        public string ProductId { get; set; }

        public string SkuInfo { get; set; }
    }
}
