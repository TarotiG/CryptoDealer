public class Ticker
{
    [JsonProperty("market")]
    public string Market { get; set; } = default!;

    [JsonProperty("price")]
    public string Price { get; set; } = default!;
}