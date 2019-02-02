using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.Miniapp.Respones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.Miniapp.Requests
{
    /// <summary>
    /// 微信小程序的模板消息
    /// </summary>
    public class WxopenTemplateSendRequest : ApiRequest<WxopenTemplateSendResponse>
    {
        /// <summary>
        /// 接受者的openid
        /// </summary>
        [JsonProperty("touser")]
        public string ToUser { get; set; }
        /// <summary>
        /// 模板消息的ID
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。
        /// </summary>
        [JsonProperty("page")]
        public string Page { get; set; }
        /// <summary>
        /// 表单提交场景下，为 submit 事件带上的 formId；支付场景下，为本次支付的 prepay_id
        /// </summary>
        [JsonProperty("form_id")]
        public string FormId { get; set; }

        /// <summary>
        /// 模板内容，不填则下发空模板。具体格式请参考示例。
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, TemplateDataProperty> Data { get; set; }

        /// <summary>
        /// 模板需要放大的关键词，不填则默认无放大
        /// </summary>
        [JsonProperty("emphasis_keyword")]
        public string EmphasisKeyword { get; set; }

        protected override string UrlFormat => "/cgi-bin/message/wxopen/template/send?access_token={0}";

        protected override bool NeedToken => true;

        internal override HttpRequestActionType Method => HttpRequestActionType.Content;

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
