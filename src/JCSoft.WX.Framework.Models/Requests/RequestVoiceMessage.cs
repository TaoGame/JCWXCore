using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestVoiceMessage : RequestMessage
    {
        public RequestVoiceMessage(XElement xml):base(xml)
        {
            this.MediaId = xml.Element("MediaId").Value;
            this.Format = xml.Element("Format").Value;
            this.Recognition = xml.Element("Recognition").Value;
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
