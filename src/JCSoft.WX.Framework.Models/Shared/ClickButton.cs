using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models
{
    public enum ClickButtonType
    {
        None,
        click,
        view,
        scancode_waitmsg,   //扫码推事件
        scancode_push,  //扫码推事件且弹出“消息接收中”提示框
        pic_sysphoto,   //弹出系统拍照发图
        pic_photo_or_album, //弹出拍照或者相册发图
        pic_weixin, //  弹出微信相册发图器
        location_select,     //弹出地理位置选择器
        media_id,   //下发消息（除文本消息）用户点击media_id类型按钮后，微信服务器会将开发者填写的永久素材id对应的素材下发给用户，永久素材类型可以是图片、音频、视频、图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id
        view_limited,    //跳转图文消息URL用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id
        miniprogram //小程序
    }

    public class ClickButton
    {
        [JsonProperty("type",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClickButtonType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key",
            NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("url",
            NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("sub_button",
            NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ClickButton> SubButton { get; set; }

        [JsonProperty("news_info", NullValueHandling = NullValueHandling.Ignore)]
        public NewsInfo NewsInfo { get; set; }

        [JsonProperty("appid", NullValueHandling = NullValueHandling.Ignore)]
        public string MiniProgramAppId { get; set; }

        [JsonProperty("pagePath", NullValueHandling = NullValueHandling.Ignore)]
        public string MiniProgramPagePath { get; set; }
    }
}
