public class Deposit
{
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; } = default!;

    [JsonProperty("amount")]
    public string Amount { get; set; } = default!;

    [JsonProperty("address")]
    public string Address { get; set; } = default!;

    [JsonProperty("paymentid")]
    public string PaymentId { get; set; } = default!;

    [JsonProperty("txId")]
    public string TxId { get; set; } = default!;

    [JsonProperty("fee")]
    public string Fee { get; set; } = default!;
}