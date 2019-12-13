using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models
{
    [Serializable]
    public abstract class WXMessage
    {
        protected XmlDocument doc = new XmlDocument();

        [XmlElement("FromUserName")]
        [JsonIgnore]
        public XmlCDataSection CFromUserName
        {
            get
            {
                return doc.CreateCDataSection(FromUserName);
            }
            set
            {
                FromUserName = value.Value;
            }
        }

        [XmlElement("MsgType")]
        [JsonIgnore]
        public XmlCDataSection CMsgType
        {
            get
            {
                return doc.CreateCDataSection(MsgType.ToString().ToLower());
            }
            set {; }
        }

        [XmlElement("CreateTime")]
        public long CreateTime { get; set; }

        [XmlElement("ToUserName")]
        [JsonIgnore]
        public XmlCDataSection CToUserName
        {
            get
            {
                return doc.CreateCDataSection(ToUserName);
            }
            set
            {
                ToUserName = value.Value;
            }
        }

        [XmlIgnore]
        public string FromUserName { get; set; }

        public abstract MsgType MsgType { get; }

        [XmlIgnore]
        public string ToUserName { get; set; }
    }
}
