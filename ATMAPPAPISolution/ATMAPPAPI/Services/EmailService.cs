
using System.Collections.Concurrent;
using System.Net.Mail;
using System.Net;

namespace ATMAPPAPI.Services
{
    public class EmailService : IEmailService
    {
        //Store OTPs
        private readonly ConcurrentDictionary<string, (string Otp, DateTime Timestamp)> otpStore
        = new ConcurrentDictionary<string, (string Otp, DateTime Timestamp)>();

        // Generate a random four-digit PIN
        private string GenerateOTP()
        {
            
            var random = new Random();
            var pin = random.Next(1000, 9999).ToString();
            return pin;
        }

        //Send OTP Method : Return string message
        public async Task<string> SendOTPMail(string toEmailAddress)
        {
           
            var pin = GenerateOTP();

           
            otpStore[toEmailAddress] = (pin, DateTime.UtcNow);

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("i62175973@gmail.com", "Error$1234"),
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

        //Verify OTP Method : Return string message
        public Task<string> VerifyOtp(string toEmailAddress, string enteredOtp)
        {
            if (otpStore.TryGetValue(toEmailAddress, out var otpData))
            {
                if ((DateTime.UtcNow - otpData.Timestamp).TotalHours > 2)
                {
                    return Task.FromResult("OTP has expired.");
                }

                if (otpData.Otp == enteredOtp)
                {
                    return Task.FromResult("OTP verified successfully.");
                }
                else
                {
                    return Task.FromResult("Invalid OTP.");
                }
            }
            else
            {
                return Task.FromResult("OTP not found for the given email.");
            }
        }
    }
}
