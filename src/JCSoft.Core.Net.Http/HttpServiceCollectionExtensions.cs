using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.Core.Net.Http
{
    public static class HttpServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpService(this IServiceCollection service)
        {
            service.AddSingleton<IHttpFactory, HttpFactory>();

            return service;
        }

        public static IServiceCollection AddHttpService(this IServiceCollection service, Action<HttpOptions> setupOptions)
        {
            if(setupOptions != null)
            {
                service.Configure(setupOptions);
            }
            service.AddHttpService();
            return service;
        }
    }
}
