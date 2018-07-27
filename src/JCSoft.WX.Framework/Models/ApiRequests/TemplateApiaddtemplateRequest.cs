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
    /// 获取模板ID
    /// </summary>
    public class TemplateApiaddtemplateRequest : ApiRequest<TemplateApiaddtemplateResponse>
    {
        /// <summary>
        /// 模板库中模板的编号，有“TM**”和“OPENTMTM**”等形式
        /// </summary>
        [JsonProperty("template_id_short")]
        public string TemplateIdShort { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        protected override string UrlFormat
        {
            get { return "/cgi-bin/template/api_add_template?access_token={0}"; }
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
