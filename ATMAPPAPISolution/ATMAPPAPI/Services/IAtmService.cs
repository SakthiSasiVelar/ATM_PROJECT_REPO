using ATMAPPAPI.Models;

namespace ATMAPPAPI.Services
{
    public interface IAtmService
    {
        void Deposit(int userId, decimal amount);
        void Withdraw(int userId, decimal amount);
        bool ValidateCard(CardInfo cardInfo);
        bool ValidatePin(UserCredentials credentials, string pin);
        bool ValidateOtp(UserCredentials credentials, string otp);
    }
}
