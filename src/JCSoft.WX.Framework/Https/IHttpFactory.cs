namespace JCSoft.Core.Net.Http
{
    public interface IHttpFactory
    {
        HttpAbstraction CreateHttp(HttpRequestActionType requestType);
    }
}
