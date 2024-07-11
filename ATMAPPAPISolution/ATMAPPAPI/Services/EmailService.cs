
using System.Collections.Concurrent;
using System.Net.Mail;
using System.Net;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Text;
using Google.Apis.Auth.OAuth2.Flows;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace ATMAPPAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly ConcurrentDictionary<string, (string Otp, DateTime Timestamp)> otpStore
        = new ConcurrentDictionary<string, (string Otp, DateTime Timestamp)>();

        private readonly IMemoryCache _cache;

        public EmailService(IMemoryCache cache)
        {
            _cache = cache;
        }


        public async Task<string> SendOTPMail(string toEmailAddress)
        {
            var pin = GenerateOTP();
            otpStore[toEmailAddress] = (pin, DateTime.UtcNow);
            _cache.Set("OtpStore", otpStore);


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("i62175973@gmail.com", "emou qcfn elfe nldy"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("i62175973@gmail.com"),
                Subject = "Your OTP Code",
                Body = $"Your OTP code is: {pin}",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(toEmailAddress);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                return "Email sent successfully.";
            }
            catch (Exception ex)
            {
                return $"Error sending email: {ex.Message}";
            }
        }



        private string GenerateOTP()
        {
            var random = new Random();
            return random.Next(1000, 9999).ToString();
        }

        public string VerifyOtp(string toEmailAddress, string enteredOtp)
        {
            var otpStore = _cache.Get<ConcurrentDictionary<string, (string, DateTime)>>("OtpStore");
            if (otpStore.TryGetValue(toEmailAddress, out var otpData))
            {
                if ((DateTime.UtcNow - otpData.Item2).TotalHours > 2)
                {
                    return "OTP has expired.";
                }

                if (otpData.Item1 == enteredOtp)
                {
                    return "OTP verified successfully.";
                }
                else
                {
                    return "Invalid OTP.";
                }
            }
            else
            {
                return "OTP not found for the given email.";
            }
        }
    }
}
