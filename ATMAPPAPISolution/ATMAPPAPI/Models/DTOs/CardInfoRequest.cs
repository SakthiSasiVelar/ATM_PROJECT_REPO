namespace ATMAPPAPI.Models.DTOs
{
    public class CardInfoRequest
    {
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
