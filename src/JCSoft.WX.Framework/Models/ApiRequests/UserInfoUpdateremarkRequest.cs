using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{

    /// <summary>
    /// 设置备注名
    /// 开发者可以通过该接口对指定用户设置备注名，该接口暂时开放给微信认证的服务号。 
    /// </summary>
    public class UserInfoUpdateremarkRequest : ApiRequest<DefaultResponse>
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 新的备注名，长度必须小于30字符
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        protected override string UrlFormat
        {
            get { return "/cgi-bin/user/info/updateremark?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
