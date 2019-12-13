using Newtonsoft.Json;
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
            this.Content = xml.Element("Content").GetValue();
        }

        public override MsgType MsgType
        {
            get { return MsgType.Text; }
        }

        [XmlIgnore]
        public string Content { get; set; }

        [XmlElement("Content")]
        [JsonIgnore]
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
