public class OrderBook
{
    public string Market { get; set; }
    public int Nonce { get; set; }
    public List<decimal[]> Bids { get; set; } // [prize, size]
    public List<decimal[]> Asks { get; set; } // [prize, size]

    [JsonProperty("timestamp")]
    public long TimeStampInt { get; set; }

    [JsonIgnore]
    public DateTime TimeStamp => DateTimeOffset.FromUnixTimeMilliseconds(TimeStampInt / 1000000).UtcDateTime;
}