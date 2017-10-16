using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestLocationEventMessage : RequestEventMessage
    {
        public RequestLocationEventMessage(XElement xml)
            : base(xml)
        {
            Latitude = float.Parse(xml.Element("Latitude").GetValue());
            Longitude = float.Parse(xml.Element("Longitude").GetValue());
            Precision = float.Parse(xml.Element("Precision").GetValue());
        }

        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        public float Precision { get; set; }
    }
}
