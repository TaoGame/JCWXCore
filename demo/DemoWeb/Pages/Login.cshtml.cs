using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models;
using JCSoft.WX.Framework.Api;

namespace DemoWeb.Pages
{
    public class LoginModel : BasePageModel
    {
        public LoginModel(IMemoryCache cache, IApiClient client) : base(cache, client)
        {
        }
        

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ErrorMessage = "Enter Your Corrently AppID.";
        }

        public async Task<IActionResult> OnPostAsync(string appid, string appSecret)
        {
            var appIdentity = new AppIdentication(appid, appSecret);
            var request = new AccessTokenRequest(appIdentity);
            var response = _client.Execute(request);

            IsSuccess = !response.IsError;
            if (!response.IsError)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("appid", appid));
                identity.AddClaim(new Claim("appSecret", appSecret));
                identity.AddClaim(new Claim("token", response.Access_Token));

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddSeconds(response.Expires_In))
                };
                await HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);
                if (!String.IsNullOrEmpty(ReturnUrl))
                    return Redirect(ReturnUrl);

               
                return Redirect("/");
            }
            else
            {
                ErrorMessage = response.ErrorMessage;
               
            }

            return Page();
        }
    }
}