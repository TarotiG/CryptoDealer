public class MarketModel
{
    [JsonProperty("market")]
    public string Market { get; set; } = default!;

    [JsonProperty("status")]
    public string Status { get; set; } = default!;

    [JsonProperty("base")]
    public string Base { get; set; } = default!;

    [JsonProperty("quote")]
    public string Quote { get; set; } = default!;

    [JsonProperty("price")]
    public string Price { get; set; } = default!;
}

// {
//   "market": "BTC-EUR",
//   "status": "trading",
//   "base": "BTC",
//   "quote": "EUR",
//   "pricePrecision": "5",
//   "minOrderInBaseAsset": "0.0001",
//   "minOrderInQuoteAsset": "5",
//   "maxOrderInBaseAsset": "1000000000",
//   "maxOrderInQuoteAsset": "1000000000",
//   "orderTypes": [
//     "market",
//     "limit",
//     "stopLoss",
//     "stopLossLimit",
//     "takeProfit",
//     "takeProfitLimit"
//   ],
//   "quantityDecimals": "4",
//   "notionalDecimals": "2",
//   "tickSize": "0.01",
//   "maxOpenOrders": 100,
//   "feeCategory": "A"
// }