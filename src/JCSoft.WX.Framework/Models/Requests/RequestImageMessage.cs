using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestImageMessage : RequestMessage
    {
        public RequestImageMessage(XElement xml)
            : base(xml)
        {
            this.PicUrl = xml.Element("PicUrl").GetValue();
            this.MediaId = xml.Element("MediaId").GetValue();
        }

        public override MsgType MsgType
        {
            get { return MsgType.Image; }
        }

        public string PicUrl { get; set; }

        public string MediaId { get; set; }
    }
}
