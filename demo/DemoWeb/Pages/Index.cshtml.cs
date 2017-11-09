using JCSoft.WX.Framework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace DemoWeb.Pages
{
    
    public class IndexModel : LoginedPageModel
    {
        public IndexModel(IMemoryCache cache, IApiClient client) : base(cache, client)
        {
        }
        

        public override int Index => -1;

        public override int SubIndex => 1;

        public void OnGet()
        {
            
            if (!string.IsNullOrEmpty(AccessToken))
            {
                Message = $"appid is {AppId}, token is {AccessToken}";
            }
            
        }
    }
}