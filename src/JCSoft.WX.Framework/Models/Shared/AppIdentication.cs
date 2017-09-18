using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models
{
    public class AppIdentication
    {
        public AppIdentication(string appId, string appSecret)
        {
            this.AppID = appId;
            this.AppSecret = appSecret;
        }

        public string AppID { get; set; }

        public string AppSecret { get; set; }
    }
}
