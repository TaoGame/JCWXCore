using JCSoft.WX.Framework.Exceptions;
using JCSoft.WX.Framework.Logger;
using JCSoft.WX.Framework.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Reponses
{
    public abstract class ApiRequest<T>
        where T : ApiResponse
    {
        protected const string POSTMETHOD = "POST";
        protected const string GETMETHOD = "GET";
        protected const string FILEMETHOD = "FILE";

        internal abstract string Method { get; }

        protected abstract string UrlFormat { get; }

        [JsonIgnore]
        public ILogger Logger { get; set; }

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
            Logger.Log(String.Format("method {1}, api url:{0} ",GetUrl(), this.GetType().ToString()));
            if (NeedToken && String.IsNullOrEmpty(AccessToken))
            {
                Logger.Error(new WXApiException(-99, "AccessToken 为空或已过期").ToString());
            }
        }

      

        [JsonIgnore]
        public string AccessToken { get; set; }

        public abstract string GetPostContent();
    }
}
