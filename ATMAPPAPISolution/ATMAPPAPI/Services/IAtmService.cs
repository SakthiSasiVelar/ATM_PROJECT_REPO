using ATMAPPAPI.Models;

namespace ATMAPPAPI.Services
{
    public interface IAtmService
    {
        Task<bool> ValidateCard(string cardNumber, string cvv, DateTime expiryDate);
        Task<bool> ValidatePin(int userId, string pin);
        Task<bool> ValidateOtp(int userId, string otp);
        Task<decimal> GetBalance(int userId);
        Task Deposit(int userId, decimal amount);
        Task Withdraw(int userId, decimal amount);
        Task SendOtp(int userId);
        Task SendTransactionEmail(int userId, string transactionType, decimal amount);
    }
}
