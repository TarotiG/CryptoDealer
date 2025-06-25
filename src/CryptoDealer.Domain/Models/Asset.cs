public class Asset
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = default!;

    [JsonProperty("available")]
    public string Available { get; set; } = default!;

    [JsonProperty("inOrder")]
    public string InOrder { get; set; } = default!;
}