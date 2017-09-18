using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.Exceptions
{
    public class WXApiException : Exception
    {
        public WXApiException(int code, string content) : this(code, content, null)
        {

        }

        public WXApiException(int code, string content, Exception innerExeption) :
            base(content, innerExeption)
        {
            Code = code;
            Content = content;
        }

        public int Code { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            return String.Format("error Code :{0}, msg:{1}, ex info:{2}, ex trace:{3}",
                Code,
                Content,
                this.Message,
                this.StackTrace);
        }
    }
}
