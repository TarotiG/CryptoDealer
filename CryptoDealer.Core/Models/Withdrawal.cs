public class Withdrawal
{
  [JsonProperty("symbol")]
  public string Symbol { get; set; }
  [JsonProperty("amount")]
  public string Amount { get; set; }
  [JsonProperty("address")]
  public string Address { get; set; }
  [JsonProperty("paymentid")]
  public string PaymentId { get; set; }
  [JsonProperty("addWithdrawalFee")]
  public bool AddWithdrawalFee { get; set; }

  public Withdrawal(string Symbol, string Amount, string Address)
  {
    this.Symbol = Symbol;
    this.Amount = Amount;
    this.Address = Address;
  }
}