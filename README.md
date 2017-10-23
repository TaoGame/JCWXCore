# 微信快速开发框架Core
微信公众号快速开发框架（WX MP QuickFramework) Net Core 2.0版本


## 更新内容：
1、更新至 .Net Core 2.0  
2、新增缺失的API  
3、增加被动信息的加解密  
4、自动识别微信信息，并模型绑定到相应RequestMessage  
5、自动加密输出  
6、新增被动消息Demo及简单使用Demo 


## 配置属性：  
AppID：微信公众号分配的AppId  
AppSecret：微信公众号分配的密钥  
EncodingAESKey：加密信息所使用的AES密钥  
Token：自主设置的Token  
MessageMode：消息加解密方式 0-明文模式 1-兼容模式 2-安全模式  

### 文件方式配置:    
appsettings.json：  
    {  
        "AppID":"wx000000001",  
        "AppSecret":"appscret",  
        "EncodingAESKey":"asdfasdff1123123123123",  //43位
        "Token":"123asdf",  
        "MessageMode":2 //安全模式  
    }


