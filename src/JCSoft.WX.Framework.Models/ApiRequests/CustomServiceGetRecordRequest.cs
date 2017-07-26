using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class CustomServiceGetRecordRequest : ApiRequest<CustomServiceGetRecordResponse>
    {
        [JsonProperty("starttime")]
        internal long StartTimeStamp
        {
            get
            {
                return StartTime.ConvertToTimeStamp();
            }
        }

        [JsonIgnore]
        public DateTime StartTime { get; set; }

        [JsonProperty("endtime")]
        internal long EndTimeStamp
        {
            get
            {
                return EndTime.ConvertToTimeStamp();
            }
        }

        [JsonIgnore]
        public DateTime EndTime { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("pagesize")]
        public int PageSize { get; set; }

        [JsonProperty("pageindex")]
        public int PageIndex { get; set; }

        public override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/customservice/getrecord?access_token={0}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override void Validate()
        {
            base.Validate();
            if (PageSize <= 0 || PageSize > 1000)
            {
                throw new ArgumentOutOfRangeException("pagesize", "pagesize must in 1 to 1000");
            }

            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }
        }
    }
}
