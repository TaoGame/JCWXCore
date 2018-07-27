using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public abstract class MessageCustomSendRequest : ApiRequest<MessageCustomSendResponse>
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("msgtype")]
        public abstract string MsgType { get; }

        [JsonIgnore]
        public string KfAccount { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        [JsonProperty("customservice", NullValueHandling = NullValueHandling.Ignore)]
        public CustomAccount CustomerService
        {
            get
            {
                if (!String.IsNullOrEmpty(KfAccount))
                {
                    return new CustomAccount
                    {
                        Account = KfAccount
                    };
                }

                return null;
            }
            set
            {
            }
        }

        protected override string UrlFormat
        {
            get { return "/cgi-bin/message/custom/send?access_token={0}"; }
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
