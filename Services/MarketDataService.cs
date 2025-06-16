public class MarketDataService : IMarketDataProvider
{
  private readonly ApiClientService _apiClientService = new();
  public List<MarketModel> Markets { get; set; } = new List<MarketModel>();

  public async Task<List<MarketModel>> GetMarkets()
  {
    var marketData = await _apiClientService.CreateGETRequest("/v2/markets");
    foreach (var market in JsonConvert.DeserializeObject<List<MarketModel>>(marketData))
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