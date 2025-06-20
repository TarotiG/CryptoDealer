using System.Runtime;

public class Trade
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("orderId")]
    public string OrderId { get; set; }
    [JsonProperty("clientOrderId")]
    public string ClientOrderId { get; set; }
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }
    [JsonProperty("market")]
    public string Market { get; set; }
    [JsonProperty("side")]
    public string Side { get; set; }
    [JsonProperty("amount")]
    public string Amount { get; set; }
    [JsonProperty("price")]
    public string Price { get; set; }
    [JsonProperty("taker")]
    public string Taker { get; set; }
    [JsonProperty("fee")]
    public string Fee { get; set; }
    [JsonProperty("feeCurrency")]
    public string FeeCurrency { get; set; }
    [JsonProperty("settled")]
    public string Settled { get; set; }
}