using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestLocationMessage : RequestMessage
    {
        public RequestLocationMessage(XElement xml)
            : base(xml)
        {
            this.Location_X = float.Parse(xml.Element("Location_X").Value);
            this.Location_Y = float.Parse(xml.Element("Location_Y").Value);
            this.Scale = int.Parse(xml.Element("Scale").Value);
            this.Label = xml.Element("Label").Value;
        }

        public string Label { get; set; }

        public float Location_X { get; set; }

        public float Location_Y { get; set; }

        public override MsgType MsgType
        {
            get { return MsgType.Location; }
        }
        public int Scale { get; set; }
    }
}
