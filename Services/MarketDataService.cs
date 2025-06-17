public class MarketDataService : IMarketDataProvider
{
  private readonly ApiClientService _apiClientService = new();
  public List<MarketModel> Markets { get; set; } = new List<MarketModel>();

  public async Task<List<MarketModel>> GetMarkets()
  {
    var marketData = await _apiClientService.CreateGETRequest("/v2/markets");
    var marketDataJson = JsonConvert.DeserializeObject<List<MarketModel>>(marketData);

    foreach (var market in marketDataJson)
    {
      // Alleen actieve markten toevoegen
      if (market.Status != "trading")
      {
        continue;
      }
      Markets.Add(market);
    }
    return Markets;
  }

  public async Task GetOrderBook(string market)
  {
    var orderBook = await _apiClientService.CreateGETRequest($"/v2/{market}/book");
    var orderBookJson = JsonConvert.DeserializeObject<OrderBook>(orderBook);
    LogService.LogInfo($"Order book {orderBookJson.Market} is binnengehaald");
  }

  // VERDER UITWERKEN
  public async Task<List<Candle>> GetCandleData(string market, string interval, int limit = 0)
  {
    string endpoint = limit == 0 ? $"/v2/{market}/candles?interval={interval}" : $"/v2/{market}/candles?interval={interval}&limit={limit}";

    var candleData = await _apiClientService.CreateGETRequest(endpoint);
    var candleJson = JsonConvert.DeserializeObject<List<string[]>>(candleData);

    var candles = new List<Candle>();
    
    foreach (var candle in candleJson)
    {
      candles.Add(new Candle
      {
        Timestamp = candle[0],
        Open = candle[1],
        High = candle[2],
        Low = candle[3],
        Close = candle[4],
        Volume = candle[5]
      });
    }
    return candles;
  }

  public async Task GetCurrentPrice(string asset)
  {
    var price = await _apiClientService.CreateGETRequest($"/v2/ticker/price?market={asset}");
    Console.WriteLine(price);
  }

  // Anders bouwen
  public async Task GetCurrentPrices()
  {
    var prices = await _apiClientService.CreateGETRequest("/v2/ticker/price");
    Console.WriteLine(prices);
  }

  public List<decimal> GetHistoricalPrice(string asset, DateTime date)
  {
    return new List<decimal>();
  }

  public List<decimal> GetCandles(string asset, TimeFrame timeFrame, int limit)
  {
    return new List<decimal>();
  }
}