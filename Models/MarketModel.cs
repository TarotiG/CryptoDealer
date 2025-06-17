public class MarketModel
{
  [JsonProperty]
  public string Market { get; set; }
  [JsonProperty]
  public string Status { get; set; }
  [JsonProperty]
  public string Base { get; set; }
  [JsonProperty]
  public string Quote { get; set; }
  [JsonProperty]
  public string Price { get; set; }
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