namespace CryptoDealer.Core.Models
{
    public class Investment
    {
        public string InvestmentId { get; set; } = string.Empty;
        public int OperaterId { get; set; }
        public DateTime InvestmentDate { get; set; }
        public List<Order>? Orders { get; set; }

        public Investment()
        {
            InvestmentId = Guid.NewGuid().ToString();
            InvestmentDate = DateTime.Now;
        }
    }
}
