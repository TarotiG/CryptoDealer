public class Asset
{
  [JsonProperty]
  public string Symbol { get; set; }
  [JsonProperty]
  public string Available { get; set; }
  [JsonProperty]
  public string InOrder { get; set; }
}