using Kavenegar;

namespace AutoOrder.Controllers
{
    public class SendSMS
    {
        #region Methods

        public void Send(Models.Order orderInfo, string token, string token2, string token3)
        {
            var apiKey = "4D52326248506D736C34377575394456626C7A494A4261305656306233677A4E6567556D306272714132593D";
            var api = new KavenegarApi(apiKey);
            api.VerifyLookup(orderInfo.SMSMobile, token, token2, token3, "", "", "OrderNotif", Kavenegar.Core.Models.Enums.VerifyLookupType.Sms);
        }

        #endregion
    }
}
