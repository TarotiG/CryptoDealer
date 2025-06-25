public class OrderBook
{
    [JsonProperty("market")]
    public string Market { get; set; } = default!;

    [JsonProperty("nonce")]
    public int Nonce { get; set; }

    [JsonProperty("bids")]
    public List<decimal[]>? Bids { get; set; } // [prize, size]

    [JsonProperty("asks")]
    public List<decimal[]>? Asks { get; set; } // [prize, size]

    [JsonProperty("timestamp")]
    public long TimeStampInt { get; set; }

    [JsonIgnore]
    public DateTime TimeStamp => DateTimeOffset.FromUnixTimeMilliseconds(TimeStampInt / 1000000).UtcDateTime;
}