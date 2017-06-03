using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestImageMessage : RequestMessage
    {
        public RequestImageMessage(XElement xml)
            : base(xml)
        {
            this.PicUrl = xml.Element("PicUrl").Value;
            this.MediaId = xml.Element("MediaId").Value;
        }

        public override MsgType MsgType
        {
            get { return MsgType.Image; }
        }

        public string PicUrl { get; set; }

        public string MediaId { get; set; }
    }
}
