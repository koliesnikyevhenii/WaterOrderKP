using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;
using WaterOrderKP.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var accountSid = configuration.GetValue<string>("SmsSendingData:AccountSid");
            var authToken = configuration.GetValue<string>("SmsSendingData:AuthToken");
            var fromTel = configuration.GetValue<string>("SmsSendingData:FromTel");
            tel = "+380981731016";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber(fromTel),
                to: new Twilio.Types.PhoneNumber(tel)
            );
        }
    }
}
