using JCSoft.WX.Framework.Api;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authentication;
namespace DemoWeb.Pages
{
    public class LogoutModel : LoginedPageModel
    {
        public LogoutModel(IMemoryCache cache, IApiClient client) : base(cache, client)
        {
        }

        public void OnGet()
        {
            HttpContext?.SignOutAsync();
            Response.Redirect("/login");
        }
    }
}