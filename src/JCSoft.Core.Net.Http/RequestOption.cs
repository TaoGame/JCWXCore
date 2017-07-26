using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.Core.Net.Http
{
    public class RequestOption
    {
        public string Url { get; set; }

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public string Content { get; set; } = String.Empty;

        
    }
}
