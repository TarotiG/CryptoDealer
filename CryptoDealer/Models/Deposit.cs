public class Deposit
{
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    [JsonProperty("amount")]
    public string Amount { get; set; }
    [JsonProperty("address")]
    public string Address { get; set; }
    [JsonProperty("paymentid")]
    public string PaymentId { get; set; }
    [JsonProperty("txId")]
    public string TxId { get; set; }
    [JsonProperty("fee")]
    public string Fee { get; set; }
}