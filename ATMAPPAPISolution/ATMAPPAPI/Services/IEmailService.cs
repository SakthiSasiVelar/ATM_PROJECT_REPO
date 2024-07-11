namespace ATMAPPAPI.Services
{
    public interface IEmailService
    {
        Task<string> SendOTPMail(string toEmailAddress);

        string VerifyOtp(string toEmailAddress, string enteredOtp);
    }
}
