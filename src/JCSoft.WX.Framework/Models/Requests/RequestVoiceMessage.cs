using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestVoiceMessage : RequestMessage
    {
        public RequestVoiceMessage(XElement xml):base(xml)
        {
            this.MediaId = xml.Element("MediaId").GetValue();
            this.Format = xml.Element("Format").GetValue();
            this.Recognition = xml.Element("Recognition").GetValue();
        }

        public override MsgType MsgType
        {
            get { return MsgType.Voice; }
        }

        public string MediaId { get; set; }

        public string Format { get; set; }
        
        public string Recognition { get; set; }
    }
}
