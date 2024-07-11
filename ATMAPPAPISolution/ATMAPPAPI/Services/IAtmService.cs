using ATMAPPAPI.Models;

namespace ATMAPPAPI.Services
{
    public interface IAtmService
    {
        Task<string> ValidateCard(string cardNumber, string cvv, DateTime expiryDate);
        Task<bool> ValidatePin(string accountNo, string pin);
        Task<bool> ValidateOtp(string accountNo, string otp);
        Task<decimal> GetBalance(string accountNo);
        Task Deposit(string accountNo, decimal amount);
        Task Withdraw(string accountNo, decimal amount);
        Task SendOtp(string accountNo);
        Task SendTransactionEmail(string accountNo, string transactionType, decimal amount);
    }
}
