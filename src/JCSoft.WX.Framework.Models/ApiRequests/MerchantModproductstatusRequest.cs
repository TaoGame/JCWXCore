using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantModproductstatusRequest : ApiRequest<DefaultResponse>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductID { get; set; }

        /// <summary>
        /// 商品上下架标志，0：下架， 1：上架
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        public override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/modproductstatus?access_token={0}"; }
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
            if (Status < 0 || Status > 1)
            {
                throw new ArgumentOutOfRangeException("Status is between 0 to 1");
            }
        }
    }
}
