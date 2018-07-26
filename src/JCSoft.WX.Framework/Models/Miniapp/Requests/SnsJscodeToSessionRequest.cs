using System;
using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.Miniapp.Respones;

namespace JCSoft.WX.Framework.Models.Miniapp.Requests
{
    /// <summary>
    /// 小程序使用的登录凭证校验
    /// </summary>
    public class SnsJscodeToSessionRequest : ApiRequest<SnsJscodeToSessionResponse>
    {
        /// <summary>
        /// 小程序appid
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 小程序密钥
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 通过wx.login获取的code
        /// </summary>
        public string Code { get; set; }    
        internal override HttpRequestActionType Method { get; } = HttpRequestActionType.Content;
        protected override string UrlFormat { get; } = "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code";
        internal override string GetUrl()
        {
             return String.Format(UrlFormat, AppId, AppSecret, Code );
        }

        protected override bool NeedToken { get; } = false;
        internal override string GetPostContent()
        {
            return String.Empty;
        }
    }
}