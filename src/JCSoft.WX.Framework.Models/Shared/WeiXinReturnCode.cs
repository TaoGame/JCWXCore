using JCSoft.WX.Framework.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Models
{
    public class  WeiXinReturnCodeAsMessage
    {
        static WeiXinReturnCodeAsMessage()
        {
            CodeMapMessage = new Dictionary<int, string>();
            CodeMapMessage.Add(-1, "系统繁忙，此时请开发者稍候再试");
            CodeMapMessage.Add(0, "请求成功");
            CodeMapMessage.Add(40001, "获取access_token时AppSecret错误，或者access_token无效。请开发者认真比对AppSecret的正确性，或查看是否正在为恰当的公众号调用接口");
            CodeMapMessage.Add(40002, "不合法的凭证类型");
            CodeMapMessage.Add(40003, "不合法的OpenID，请开发者确认OpenID（该用户）是否已关注公众号，或是否是其他公众号的OpenID");
            CodeMapMessage.Add(40004, "不合法的媒体文件类型");
            CodeMapMessage.Add(40005, "不合法的文件类型");
            CodeMapMessage.Add(40006, "不合法的文件大小");
            CodeMapMessage.Add(40007, "不合法的媒体文件id");
            CodeMapMessage.Add(40008, "不合法的消息类型");
            CodeMapMessage.Add(40009, "不合法的图片文件大小");
            CodeMapMessage.Add(40010, "不合法的语音文件大小");
            CodeMapMessage.Add(40011, "不合法的视频文件大小");
            CodeMapMessage.Add(40012, "不合法的缩略图文件大小");
            CodeMapMessage.Add(40013, "不合法的AppID，请开发者检查AppID的正确性，避免异常字符，注意大小写");
            CodeMapMessage.Add(40014, "不合法的access_token，请开发者认真比对access_token的有效性（如是否过期），或查看是否正在为恰当的公众号调用接口");
            CodeMapMessage.Add(40015, "不合法的菜单类型");
            CodeMapMessage.Add(40016, "不合法的按钮个数");
            CodeMapMessage.Add(40017, "不合法的按钮个数");
            CodeMapMessage.Add(40018, "不合法的按钮名字长度");
            CodeMapMessage.Add(40019, "不合法的按钮KEY长度");
            CodeMapMessage.Add(40020, "不合法的按钮URL长度");
            CodeMapMessage.Add(40021, "不合法的菜单版本号");
            CodeMapMessage.Add(40022, "不合法的子菜单级数");
            CodeMapMessage.Add(40023, "不合法的子菜单按钮个数");
            CodeMapMessage.Add(40024, "不合法的子菜单按钮类型");
            CodeMapMessage.Add(40025, "不合法的子菜单按钮名字长度");
            CodeMapMessage.Add(40026, "不合法的子菜单按钮KEY长度");
            CodeMapMessage.Add(40027, "不合法的子菜单按钮URL长度");
            CodeMapMessage.Add(40028, "不合法的自定义菜单使用用户");
            CodeMapMessage.Add(40029, "不合法的oauth_code");
            CodeMapMessage.Add(40030, "不合法的refresh_token");
            CodeMapMessage.Add(40031, "不合法的openid列表");
            CodeMapMessage.Add(40032, "不合法的openid列表长度");
            CodeMapMessage.Add(40033, "不合法的请求字符，不能包含\\uxxxx格式的字符");
            CodeMapMessage.Add(40035, "不合法的参数");
            CodeMapMessage.Add(40038, "不合法的请求格式");
            CodeMapMessage.Add(40039, "不合法的URL长度");
            CodeMapMessage.Add(40050, "不合法的分组id");
            CodeMapMessage.Add(40051, "分组名字不合法");
            CodeMapMessage.Add(40060, "删除单篇图文时，指定的 article_idx 不合法");
            CodeMapMessage.Add(40117, "分组名字不合法");
            CodeMapMessage.Add(40118, "media_id大小不合法");
            CodeMapMessage.Add(40119, "button类型错误");
            CodeMapMessage.Add(40120, "button类型错误");
            CodeMapMessage.Add(40121, "不合法的media_id类型");
            CodeMapMessage.Add(40132, "微信号不合法");
            CodeMapMessage.Add(40137, "不支持的图片格式");
            CodeMapMessage.Add(40155, "请勿添加其他公众号的主页链接");
            CodeMapMessage.Add(41001, "缺少access_token参数");
            CodeMapMessage.Add(41002, "缺少appid参数");
            CodeMapMessage.Add(41003, "缺少refresh_token参数");
            CodeMapMessage.Add(41004, "缺少secret参数");
            CodeMapMessage.Add(41005, "缺少多媒体文件数据");
            CodeMapMessage.Add(41006, "缺少media_id参数");
            CodeMapMessage.Add(41007, "缺少子菜单数据");
            CodeMapMessage.Add(41008, "缺少oauth code");
            CodeMapMessage.Add(41009, "缺少openid");
            CodeMapMessage.Add(42001, "access_token超时，请检查access_token的有效期，请参考基础支持-获取access_token中，对access_token的详细机制说明");
            CodeMapMessage.Add(42002, "refresh_token超时");
            CodeMapMessage.Add(42003, "oauth_code超时");
            CodeMapMessage.Add(42007, "用户修改微信密码，accesstoken和refreshtoken失效，需要重新授权");
            CodeMapMessage.Add(43001, "需要GET请求");
            CodeMapMessage.Add(43002, "需要POST请求");
            CodeMapMessage.Add(43003, "需要HTTPS请求");
            CodeMapMessage.Add(43004, "需要接收者关注");
            CodeMapMessage.Add(43005, "需要好友关系");
            CodeMapMessage.Add(43019, "需要将接收者从黑名单中移除");
            CodeMapMessage.Add(44001, "多媒体文件为空");
            CodeMapMessage.Add(44002, "POST的数据包为空");
            CodeMapMessage.Add(44003, "图文消息内容为空");
            CodeMapMessage.Add(44004, "文本消息内容为空");
            CodeMapMessage.Add(45001, "多媒体文件大小超过限制");
            CodeMapMessage.Add(45002, "消息内容超过限制");
            CodeMapMessage.Add(45003, "标题字段超过限制");
            CodeMapMessage.Add(45004, "描述字段超过限制");
            CodeMapMessage.Add(45005, "链接字段超过限制");
            CodeMapMessage.Add(45006, "图片链接字段超过限制");
            CodeMapMessage.Add(45007, "语音播放时间超过限制");
            CodeMapMessage.Add(45008, "图文消息超过限制");
            CodeMapMessage.Add(45009, "接口调用超过限制");
            CodeMapMessage.Add(45010, "创建菜单个数超过限制");
            CodeMapMessage.Add(45011, "API调用太频繁，请稍候再试");
            CodeMapMessage.Add(45015, "回复时间超过限制");
            CodeMapMessage.Add(45016, "系统分组，不允许修改");
            CodeMapMessage.Add(45017, "分组名字过长");
            CodeMapMessage.Add(45018, "分组数量超过上限");
            CodeMapMessage.Add(45047, "客服接口下行条数超过上限");
            CodeMapMessage.Add(46001, "不存在媒体数据");
            CodeMapMessage.Add(46002, "不存在的菜单版本");
            CodeMapMessage.Add(46003, "不存在的菜单数据");
            CodeMapMessage.Add(46004, "不存在的用户");
            CodeMapMessage.Add(47001, "解析JSON/XML内容错误");
            CodeMapMessage.Add(48001, "api功能未授权，请确认公众号已获得该接口，可以在公众平台官网-开发者中心页中查看接口权限");
            CodeMapMessage.Add(48002, "粉丝拒收消息（粉丝在公众号选项中，关闭了“接收消息”）");
            CodeMapMessage.Add(48004, "api接口被封禁，请登录mp.weixin.qq.com查看详情");
            CodeMapMessage.Add(48005, "api禁止删除被自动回复和自定义菜单引用的素材");
            CodeMapMessage.Add(48006, "api禁止清零调用次数，因为清零次数达到上限");
            CodeMapMessage.Add(50001, "用户未授权该api");
            CodeMapMessage.Add(50002, "用户受限，可能是违规后接口被封禁");
            CodeMapMessage.Add(61451, "参数错误(invalid parameter)");
            CodeMapMessage.Add(61452, "无效客服账号(invalid kf_account)");
            CodeMapMessage.Add(61453, "客服帐号已存在(kf_account exsited)");
            CodeMapMessage.Add(61454, "客服帐号名长度超过限制(仅允许10个英文字符，不包括@及@后的公众号的微信号)(invalid   kf_acount length)");
            CodeMapMessage.Add(61455, "客服帐号名包含非法字符(仅允许英文+数字)(illegal character in     kf_account)");
            CodeMapMessage.Add(61456, "客服帐号个数超过限制(10个客服账号)(kf_account count exceeded)");
            CodeMapMessage.Add(61457, "无效头像文件类型(invalid   file type)");
            CodeMapMessage.Add(61450, "系统错误(system error)");
            CodeMapMessage.Add(61500, "日期格式错误");
            CodeMapMessage.Add(65301, "不存在此menuid对应的个性化菜单");
            CodeMapMessage.Add(65302, "没有相应的用户");
            CodeMapMessage.Add(65303, "没有默认菜单，不能创建个性化菜单");
            CodeMapMessage.Add(65304, "MatchRule信息为空");
            CodeMapMessage.Add(65305, "个性化菜单数量受限");
            CodeMapMessage.Add(65306, "不支持个性化菜单的帐号");
            CodeMapMessage.Add(65307, "个性化菜单信息为空");
            CodeMapMessage.Add(65308, "个性化菜单开关处于关闭状态");
            CodeMapMessage.Add(65309, "图文消息超过限制");
            CodeMapMessage.Add(65310, "填写了省份或城市信息，国家信息不能为空");
            CodeMapMessage.Add(65311, "填写了城市信息，省份信息不能为空");
            CodeMapMessage.Add(65312, "不合法的国家信息");
            CodeMapMessage.Add(65313, "不合法的省份信息");
            CodeMapMessage.Add(65314, "不合法的城市信息");
            CodeMapMessage.Add(65316, "该公众号的菜单设置了过多的域名外跳（最多跳转到3个域名的链接）");
            CodeMapMessage.Add(65317, "不合法的URL");
            CodeMapMessage.Add(9001001, "POST数据参数不合法");
            CodeMapMessage.Add(9001002, "远端服务不可用");
            CodeMapMessage.Add(9001003, "Ticket不合法");
            CodeMapMessage.Add(9001004, "获取摇周边用户信息失败");
            CodeMapMessage.Add(9001005, "获取商户信息失败");
            CodeMapMessage.Add(9001006, "获取OpenID失败");
            CodeMapMessage.Add(9001007, "上传文件缺失");
            CodeMapMessage.Add(9001008, "上传素材的文件类型不合法");
            CodeMapMessage.Add(9001009, "上传素材的文件尺寸不合法");
            CodeMapMessage.Add(9001010, "上传失败");
            CodeMapMessage.Add(9001020, "帐号不合法");
            CodeMapMessage.Add(9001021, "已有设备激活率低于50%，不能新增设备");
            CodeMapMessage.Add(9001022, "设备申请数不合法，必须为大于0的数字");
            CodeMapMessage.Add(9001023, "已存在审核中的设备ID申请");
            CodeMapMessage.Add(9001024, "一次查询设备ID数量不能超过50");
            CodeMapMessage.Add(9001025, "设备ID不合法");
            CodeMapMessage.Add(9001026, "页面ID不合法");
            CodeMapMessage.Add(9001027, "页面参数不合法");
            CodeMapMessage.Add(9001028, "一次删除页面ID数量不能超过10");
            CodeMapMessage.Add(9001029, "页面已应用在设备中，请先解除应用关系再删除");
            CodeMapMessage.Add(9001030, "一次查询页面ID数量不能超过50");
            CodeMapMessage.Add(9001031, "时间区间不合法");
            CodeMapMessage.Add(9001032, "保存设备与页面的绑定关系参数错误");
            CodeMapMessage.Add(9001033, "门店ID不合法");
            CodeMapMessage.Add(9001034, "设备备注信息过长");
            CodeMapMessage.Add(9001035, "设备申请参数不合法");
            CodeMapMessage.Add(9001036, "查询起始值begin不合法");
        }

        public static string AsMessage(int code)
        {
            if (CodeMapMessage.ContainsKey(code))
            {
                return CodeMapMessage[code];
            }

            throw new WXApiException(WXErrorCode.InvalidReturnCode, "Invalid Return Code, please send a email to me, james#taogame.com");
        }

        private static IDictionary<int, string> CodeMapMessage { get; set; }
    }
}
