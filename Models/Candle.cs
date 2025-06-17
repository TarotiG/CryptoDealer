public class CandleData
{
 public List<Candle> Candles { get; set; }
}

public class Candle
{
    public long Timestamp { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public decimal Volume { get; set; }

    public DateTime TimeStamp => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).UtcDateTime;
}