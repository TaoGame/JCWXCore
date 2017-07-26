using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class CustomserviceKfaccountUploadheadimgRequest : ApiRequest<MerchantCategoryGetskuResponse>
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 完整客服账号，格式为：账号前缀@公众号微信号
        /// </summary>
        [JsonProperty("kf_account")]
        public string Account { get; set; }

        public override string Method
        {
            get { return FILEMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/customservice/kfacount/uploadheadimg?access_token={0}&kf_account={1}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, Account);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return this.FilePath;
        }
    }
}
