using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class SnsUserInfoRequest : ApiRequest<SnsUserInfoResponse>
    {
        public string OAuthToken { get; set; }

        public string OpenId { get; set; }

        public Language Lang { get; set; }

        private string LangString { get; set; }

        public override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, OAuthToken, OpenId, LangString);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        public override string GetPostContent()
        {
            return String.Empty;
        }

        public override void Validate()
        {
            base.Validate();
            if (String.IsNullOrEmpty(OAuthToken))
                throw new ArgumentNullException("Need OAuth AccessToken");
            if (String.IsNullOrEmpty(OpenId))
                throw new ArgumentNullException("Need OpenID");

            switch (Lang)
            {

                case Language.TW:
                    LangString = "zh_TW";
                    break;
                case Language.EN:
                    LangString = "en";
                    break;
                case Language.CN:
                default:
                    LangString = "zh_CN";
                    break;
            }
        }
    }
}
