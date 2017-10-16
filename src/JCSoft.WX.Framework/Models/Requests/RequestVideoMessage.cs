using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestVideoMessage : RequestMessage
    {
        public RequestVideoMessage(XElement xml)
            : base(xml)
        {
            this.MediaId = xml.Element("MediaId").GetValue();
            this.ThumbMediaId = xml.Element("ThumbMediaId").GetValue();
        }

        public override MsgType MsgType
        {
            get { return MsgType.Video; }
        }

        public string MediaId { get; set; }

        public string ThumbMediaId { get; set; }
    }
}
