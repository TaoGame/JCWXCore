using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class CustomserviceKfaccountDelRequest : ApiRequest<DefaultResponse>
    {
        /// <summary>
        /// 完整客服账号，格式为：账号前缀@公众号微信号
        /// </summary>
        [JsonProperty("kf_account")]
        public string Account { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "/customservice/kfaccount/del?access_token=ACCESS_TOKEN&kf_account=KFACCOUNT"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, Account);
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
