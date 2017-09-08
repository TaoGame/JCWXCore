using JCSoft.WX.Framework.Api;
using JCSoft.WX.Framework.Models;
using JCSoft.WX.Framework.Models.ApiRequests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Controllers
{
    [Route("api/menuCreate")]
    public class MenuCreateController : BaseController
    {
        public MenuCreateController(IApiClient client) : base(client)
        {
        }

        public JsonResult Get()
        {
            var request = new MenuCreateRequest
            {
                Buttons = new List<ClickButton>
                {
                    new ClickButton
                    {
                        Type = ClickButtonType.click,
                        Name = "关注我",
                        Key = "Key_Follow_Me"
                    },
                    new ClickButton
                    {
                        Type = ClickButtonType.view,
                        Url = "http://inday.cnblogs.com",
                        Name = "我的博客"
                    },
                    new ClickButton
                    {
                        Name="主菜单",
                        SubButton = new List<ClickButton>
                        {
                            new ClickButton
                            {
                                Type = ClickButtonType.scancode_push,
                                Name = "扫一扫",
                                Key = "Event_Scan"
                            },
                            new ClickButton
                            {
                                Type = ClickButtonType.pic_sysphoto,
                                Name = "系统拍照发图",
                                Key = "Event_SysPhoto"
                            },
                            new ClickButton
                            {
                                Type = ClickButtonType.pic_weixin,
                                Name = "微信相册发图",
                                Key = "Event_Pic_WeiXin"
                            },
                            new ClickButton
                            {
                                Type = ClickButtonType.location_select,
                                Name = "发送位置",
                                Key = "Event_Location_Select"
                            }
                        }
                    }
                },
                AccessToken = AccessToken
            };

            var response = _client.Execute(request);

            return new JsonResult(response);
        }
    }
}
