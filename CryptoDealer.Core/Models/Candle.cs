public class CandleData
{
    [JsonProperty("candles")]
    public List<Candle>? Candles { get; set; }
}

public class Candle
{
    public string Timestamp { get; set; } = default!;
    public string Open { get; set; } = default!;
    public string High { get; set; } = default!;
    public string Low { get; set; } = default!;
    public string Close { get; set; } = default!;
    public string Volume { get; set; } = default!;

    [JsonIgnore]
    public DateTime TimeStamp => DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(Timestamp)).UtcDateTime;
}