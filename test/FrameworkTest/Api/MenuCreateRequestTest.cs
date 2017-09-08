using FrameworkCoreTest;
using JCSoft.WX.Framework.Models;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.FrameworkTest.Api
{
    public class MenuCreateRequestTest :
        MockPostApiBaseTest<MenuCreateRequest, MenuCreateResponse>
    {
        protected MenuCreateRequestTest()
        {
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40029,\"errmsg\":\"invalid code\"}";
            }

            return @"{
                ""recordlist"": [
                    {
                        ""worker"": "" test1"",
                        ""openid"": ""oDF3iY9WMaswOPWjCIp_f3Bnpljk"",
                        ""opercode"": 2002,
                        ""time"": 1400563710,
                        ""text"": "" 您好，客服test1为您服务。""
                    },
                    {
                        ""worker"": "" test1"",
                        ""openid"": ""oDF3iY9WMaswOPWjCIp_f3Bnpljk"",
                        ""opercode"": 2003,
                        ""time"": 1400563731,
                        ""text"": "" 你好，有什么事情？ ""
                    },
                ]
            }";
        }

        protected override MenuCreateRequest InitRequestObject()
        {
            return new MenuCreateRequest
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
                            },
                            new ClickButton
                            {
                                Type = ClickButtonType.miniprogram,
                                Name = "我的小程序",
                                Url ="http://inday.cnblogs.com",
                                MiniProgramAppId = "wx286b93c14bbf93aa",
                                MiniProgramPagePath = "pages/lunar/index"
                            }
                        }
                    }
                }
            };
        }
    }
}
