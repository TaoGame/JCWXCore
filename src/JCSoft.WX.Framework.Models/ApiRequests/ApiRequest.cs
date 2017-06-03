using JCSoft.WX.Framework.Models.ApiResponses;
using Newtonsoft.Json;
using System;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public abstract class ApiRequest<T>
        where T : ApiResponse
    {
        protected const string POSTMETHOD = "POST";
        protected const string GETMETHOD = "GET";
        protected const string FILEMETHOD = "FILE";

        internal abstract string Method { get; }

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

        internal virtual void Validate()
        {
            if (NeedToken && String.IsNullOrEmpty(AccessToken))
            {
                throw new ArgumentNullException("AccessToken 为空或已过期");
            }
        }

        public override string ToString()
        {
            return String.Format("method {1}, api url:{0} ", GetUrl(), this.GetType().ToString());
        }

        [JsonIgnore]
        public string AccessToken { get; set; }

        public abstract string GetPostContent();
    }
}