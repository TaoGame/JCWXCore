using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.Miniapp.Respones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.Miniapp.Requests
{
    public class WxopenTemplateListRequest : ApiRequest<WxopenTemplateListResponse>
    {
        protected override string UrlFormat => "/cgi-bin/wxopen/template/list?access_token={0}";

        protected override bool NeedToken => true;

        internal override HttpRequestActionType Method => HttpRequestActionType.Content;
        /// <summary>
        /// 用于分页，表示从offset开始。从 0 开始计数。
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// 用于分页，表示拉取count条记录。最大为 20。最后一页的list长度可能小于请求的count
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }
    }
}
