using JCSoft.WX.Framework.Reponses;
using JCSoft.WX.Framework.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework
{
    public interface IApiClient
    {
        T Execute<T>(ApiRequest<T> request) where T : ApiResponse, new();
    }
}
