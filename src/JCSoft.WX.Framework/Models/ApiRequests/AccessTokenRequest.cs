using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class AccessTokenRequest : ApiRequest<AccessTokenResponse>
    {
        public AccessTokenRequest(AppIdentication id)
        {
            AppIdentity = id;
        }

        public AppIdentication AppIdentity { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AppIdentity.AppID, AppIdentity.AppSecret);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        public override void Validate()
        {
            if (AppIdentity == null)
            {
                throw new ArgumentNullException("AppIdentity");
            }
        }

        internal override string GetPostContent()
        {
            return String.Empty;
        }
    }
}
