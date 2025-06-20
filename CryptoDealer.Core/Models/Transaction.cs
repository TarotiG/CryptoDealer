/// <summary>
/// Model voor een transaction
/// </summary>
public class Transaction
{
  [JsonProperty]
  public string TransactionId { get; set; }
  [JsonProperty]
  public DateTime ExecutedAt { get; set; }
  [JsonProperty]
  public string Type { get; set; }
  [JsonProperty]
  public string PriceCurrency { get; set; }
  [JsonProperty]
  public decimal PriceAmount { get; set; }
  [JsonProperty]
  public string SentCurrency { get; set; }
  [JsonProperty]
   public decimal SentAmount { get; set; }
  [JsonProperty]
  public string ReceivedCurrency { get; set; }
  [JsonProperty]
  public decimal ReceivedAmount { get; set; }
  [JsonProperty]
  public string FeesCurrency { get; set; }
  [JsonProperty]
  public decimal FeesAmount { get; set; }
  [JsonProperty]
  public string Address { get; set; }
}