using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestLinkMessage : RequestMessage
    {
        public RequestLinkMessage(XElement xml)
            : base(xml)
        {
            this.Title = xml.Element("Title").Value;
            this.Description = xml.Element("Description").Value;
            this.Url = xml.Element("Url").Value;
        }

        public override MsgType MsgType
        {
            get { return MsgType.Link; }
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}
