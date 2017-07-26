using JCSoft.WX.Framework.Api;
using Microsoft.Extensions.DependencyInjection;

namespace JCSoft.WX.Framework
{
    public static class WXFrameworkServiceCollectionExtensions
    {
        public static IServiceCollection AddWXFramework(this IServiceCollection service)
        {
            service.AddTransient<IApiClient, DefaultApiClient>();

            return service;
        }
    }
}
