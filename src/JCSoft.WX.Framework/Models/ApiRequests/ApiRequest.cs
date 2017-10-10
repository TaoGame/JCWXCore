using JCSoft.WX.Framework.Models.ApiResponses;
using Newtonsoft.Json;
using System;
using JCSoft.WX.Framework.Models.Exceptions;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public abstract class ApiRequest<T>
        where T : ApiResponse
    {

        internal abstract HttpRequestActionType Method { get; }

        protected abstract string UrlFormat { get; }

        internal abstract string GetUrl();

        protected abstract bool NeedToken { get; }

        internal virtual bool NotHasResponse
        {
            get
            {
                return false;
            }
        }

        public virtual void Validate()
        {
            if (NeedToken && String.IsNullOrEmpty(AccessToken))
            {
                throw new WXApiException(WXErrorCode.AccessTokenIsExpired, "AccessToken 为空或已过期");
            }
        }

        public override string ToString()
        {
            return String.Format("method {1}, api url:{0} ", GetUrl(), this.GetType().ToString());
        }

        [JsonIgnore]
        public string AccessToken { get; set; }


        internal abstract string GetPostContent();
    }
}