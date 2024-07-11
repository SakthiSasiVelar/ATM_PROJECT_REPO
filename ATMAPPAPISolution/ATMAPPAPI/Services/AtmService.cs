
using ATMAPPAPI.Models;
using ATMAPPAPI.Models.DTOs;
using ATMAPPAPI.Repositoris;
using System.Text.Json;

namespace ATMAPPAPI.Services
{
    public class AtmService : IAtmService
    {
        private readonly ICardValidationService _cardValidationService;
        private readonly ICardOperations _cardOperations;
        public AtmService(ICardValidationService cardValidationService, ICardOperations cardOperations)
        {
            _cardValidationService = cardValidationService;
            _cardOperations = cardOperations;
        }

        public async Task Deposit(string accountNo, decimal amount)
        {
            var cardInfo = await _cardOperations.FindCardInfoAsync("accountNumber", accountNo);
            if(cardInfo != null)
            {
                decimal.TryParse(cardInfo.Balance, out decimal parsedBalanced);
                parsedBalanced += amount;
                cardInfo.Balance = parsedBalanced.ToString();
                // Update the card info in the JSON file
                await _cardOperations.UpdateCardInfoAsync(cardInfo);
            }
        }

       

        public async Task<decimal> GetBalance(string accountNo)
        {
           var cardInfo = await _cardOperations.FindCardInfoAsync("accountNumber", accountNo);
            if (cardInfo != null)
            {
                decimal.TryParse(cardInfo.Balance, out decimal parsedBalanced);
                return parsedBalanced;
            }
            throw new InvalidOperationException("Account not found");
        }

        public Task SendOtp(string accountNo)
        {
            throw new NotImplementedException();
        }

        public Task SendTransactionEmail(string accountNo, string transactionType, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ValidateCard(string cardNumber, string cvv, DateTime expiryDate)
        {
            if (await _cardValidationService.ValidateCard(cardNumber, cvv, expiryDate))
            {
                var cardInfo = await _cardOperations.FindCardInfoAsync("cardNumber", cardNumber);
               
                if (cardInfo != null)
                {
                    return cardInfo.AccountNumber;
                }
            }
            return null;
        }

        public Task<bool> ValidateOtp(string accountNo, string otp)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidatePin(string accountNo, string pin)
        {
            var cardInfo = await _cardOperations.FindCardInfoAsync("accountNumber", accountNo);
            if (cardInfo != null)
            {
                return cardInfo.Pin == pin;
            }
            return false;
        }

        public async Task Withdraw(string accountNo, decimal amount)
        {
            var cardInfo = await _cardOperations.FindCardInfoAsync("accountNumber", accountNo);
            if (cardInfo != null)
            {
                var balance = decimal.TryParse(cardInfo.Balance, out decimal parsedBalanced);
                if ( balance && parsedBalanced >= amount)
                {
                    parsedBalanced -= amount;
                    cardInfo.Balance = parsedBalanced.ToString();
                    // Update the card info in the JSON file
                    await _cardOperations.UpdateCardInfoAsync(cardInfo);
                }
            }
        }

       
    }
}
