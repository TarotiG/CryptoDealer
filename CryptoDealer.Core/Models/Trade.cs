using System.Runtime;

public class Trade
{
    [JsonProperty("id")]
    public string Id { get; set; } = default!;

    [JsonProperty("orderId")]
    public string OrderId { get; set; } = default!;

    [JsonProperty("clientOrderId")]
    public string ClientOrderId { get; set; } = default!;

    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }

    [JsonProperty("market")]
    public string Market { get; set; } = default!;

    [JsonProperty("side")]
    public string Side { get; set; } = default!;

    [JsonProperty("amount")]
    public string Amount { get; set; } = default!;

    [JsonProperty("price")]
    public string Price { get; set; } = default!;

    [JsonProperty("taker")]
    public string Taker { get; set; } = default!;

    [JsonProperty("fee")]
    public string Fee { get; set; } = default!;

    [JsonProperty("feeCurrency")]
    public string FeeCurrency { get; set; } = default!;

    [JsonProperty("settled")]
    public string Settled { get; set; } = default!;
}