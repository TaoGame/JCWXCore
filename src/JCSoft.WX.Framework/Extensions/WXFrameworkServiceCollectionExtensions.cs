using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Api;
using JCSoft.WX.Framework.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WXFrameworkServiceCollectionExtensions
    {
        public static IServiceCollection AddWXFramework(this IServiceCollection service)
        {
            service.AddHttpService();
            service.AddTransient<IApiClient, DefaultApiClient>();

            return service;
        }

        public static IServiceCollection AddWXFramework(this IServiceCollection service, Action<WXOptions> setupOptions)
        {
            if (setupOptions != null)
            {
                service.Configure(setupOptions);
            }

            service.AddWXFramework();
            return service;
        }
    }
}
