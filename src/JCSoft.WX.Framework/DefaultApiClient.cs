using JCSoft.WX.Framework.Common;
using JCSoft.WX.Framework.Logger;
using JCSoft.WX.Framework.Reponses;
using JCSoft.WX.Framework.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JCSoft.WX.Framework
{
    public class DefaultApiClient : IApiClient
    {
        private static readonly LoggerHelper Logger = LoggerHelper.Instance;

        public virtual string DoExecute<T>(ApiRequest<T> request)
            where T : ApiResponse
        {
            var url = request.GetUrl();
            var result = String.Empty;
            switch (request.Method)
            {
                case "FILE":
                    result = HttpHelper.HttpUploadFile(url, request.GetPostContent());
                    break;
                case "POST":
                    result = HttpHelper.HttpPost(url, request.GetPostContent());
                    break;
                case "GET":
                default:
                    result = HttpHelper.HttpGet(url);
                    break;
            }

            return result;

        }

        public T Execute<T>(ApiRequest<T> request)
                    where T : ApiResponse, new()
        {
            request.Validate();

            var execResult = DoExecute(request);
            T result = null;
            try
            {
                result = JsonConvert.DeserializeObject<T>(execResult);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                result = null;
            }

            if (result == null)
            {
                if (request.NotHasResponse)
                {
                    return new T();
                }
                else
                {
                    Logger.Error($"the request not has response {request.GetType()}");
                    throw new WebException();
                }
            }

            return result;
        }
    }
}
