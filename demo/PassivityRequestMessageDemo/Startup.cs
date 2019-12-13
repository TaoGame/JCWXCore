using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using JCSoft.WX.Framework.Extensions;
using JCSoft.WX.Mvc.Formatters;

namespace PassivityRequestMessageDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<WXOptions>(Configuration);
            services.Configure<MvcOptions>(options =>
            {
                options.InputFormatters.Add(new WechatXmlSerializerInputFormatter(
                        Configuration.GetValue<string>("Token"),
                        Configuration.GetValue<string>("EncodingAESKey"),
                        Configuration.GetValue<string>("AppId"),
                        Configuration.GetValue<MessageMode>("MessageMode")
                    ));

                options.OutputFormatters.Add(new WechatXmlSerializerOutputFormatter(
                        Configuration.GetValue<string>("Token"),
                        Configuration.GetValue<string>("EncodingAESKey"),
                        Configuration.GetValue<string>("AppId"),
                        Configuration.GetValue<MessageMode>("MessageMode")
                    ));
            });


            services.AddWXFramework();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Trace);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
