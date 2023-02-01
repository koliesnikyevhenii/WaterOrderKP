using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WaterOrderKP.Services
{
    public interface IKpSmsService
    {
        void SendSms(string tel, string msg);
    }

    public class KpSmsService : IKpSmsService
    {
        public void SendSms(string tel, string msg)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "AC9a711510044ffbc989c03010ff3c8216";
            string authToken = "9c09d2e490d1e323de3b979e8b8ea6bd";
            string fromTel = "+15175505876";
            tel = "+380508092413";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber(fromTel),
                to: new Twilio.Types.PhoneNumber(tel)
            );


        }
    }
}
