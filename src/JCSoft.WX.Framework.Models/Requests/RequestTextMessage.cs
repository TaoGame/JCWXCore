using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Requests
{
    [Serializable]
    [XmlRoot("xml", 
        Namespace="")]
    public class RequestTextMessage : RequestMessage
    {
        public RequestTextMessage() { }

        public RequestTextMessage(XElement xml)
            : base(xml)
        {
            this.Content = xml.Element("Content").Value;
        }

        public override MsgType MsgType
        {
            get { return MsgType.Text; }
        }

        [XmlIgnore]
        public string Content { get; set; }

        [XmlElement("Content")]
        public XmlCDataSection CContent
        {
            get
            {
                return doc.CreateCDataSection(Content.ToString());
            }
            set
            {
                Content = value.Value;
            }
        }
    }
}
