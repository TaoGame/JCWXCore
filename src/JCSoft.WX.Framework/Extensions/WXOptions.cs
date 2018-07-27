using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Extensions
{
    public class WXOptions
    {
        public string AppId { get; set; }

        public string AppSecert { get; set; }

        public string Token { get; set; }

        public MessageMode MessageMode { get; set; }

        public string EncodingAESKey { get; set; }
        public string ApiUrl { get; set; } = "https://api.weixin.qq.com";
    }

    public enum MessageMode
    {
        ClearText  = 0,
        Compatible = 1,
        Cipher = 2
    }
}
