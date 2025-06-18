public class CandleData
{
 public List<Candle> Candles { get; set; }
}

public class Candle
{
    public string Timestamp { get; set; }
    public string Open { get; set; }
    public string High { get; set; }
    public string Low { get; set; }
    public string Close { get; set; }
    public string Volume { get; set; }

    [JsonIgnore]
    public DateTime TimeStamp => DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(Timestamp)).UtcDateTime;
}