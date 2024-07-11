namespace ATMAPPAPI.Services
{
    public interface IEmailService
    {
        Task<string> SendOTPMail(string toEmailAddress);

        Task<string> VerifyOtp(string toEmailAddress, string enteredOtp);
    }
}
