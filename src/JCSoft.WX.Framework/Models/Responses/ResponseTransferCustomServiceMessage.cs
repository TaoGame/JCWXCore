using JCSoft.WX.Framework.Models.Requests;

namespace JCSoft.WX.Framework.Models.Responses
{
    public class ResponseTransferCustomServiceMessage : ResponseMessage
    {
         public ResponseTransferCustomServiceMessage() { }
         public ResponseTransferCustomServiceMessage(RequestMessage request)
            : base(request)
        {
        }

         public override MsgType MsgType
         {
             get
             {
                 return MsgType.transfer_customer_service;
             }
         }
    }
}
