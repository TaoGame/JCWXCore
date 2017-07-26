using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Api
{
    public interface IApiClient
    {
        T Execute<T>(ApiRequest<T> request) where T : ApiResponse, new();
    }
}
