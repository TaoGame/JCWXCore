using JCSoft.WX.Framework.Models.ApiResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models.Miniapp.Respones
{
    public class WxopenTemplateListResponse : ApiResponse
    {
        [JsonProperty("list")]
        public List<WxopenTemplateList> List { get; set; }
    }
    public class WxopenTemplateList
    {
        /// <summary>
        /// 添加至帐号下的模板id，发送小程序模板消息时所需
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
        /// <summary>
        /// 模板标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 模板内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 模板内容示例
        /// </summary>
        public string Example { get; set; }
    }
}
