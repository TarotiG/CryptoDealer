using CryptoDealer.Core.Interfaces;
using CryptoDealer.Core.Utilities;
using System.Net;

public class MarketDataService : IMarketDataProvider
{
    private readonly IApiClient _apiClientService;

    public MarketDataService(IApiClient apiClientService)
    {
        _apiClientService = apiClientService;
    }

    public async Task<List<MarketModel>> GetMarkets(string? market)
    {
        List<MarketModel> activeMarkets = new List<MarketModel>();
        string endpoint = "/v2/markets";

        EndpointBuilder _endpoint = new EndpointBuilder(
            endpoint,
            EndpointBuilder.ToDictionary(new
            {
                market
            }));

        var marketData = await _apiClientService.CreateGETRequest(_endpoint._Uri);
        List<MarketModel>? marketDataJson = JsonConvert.DeserializeObject<List<MarketModel>>(marketData);
    
        if (marketDataJson != null && marketDataJson.Count > 0)
        {
            foreach (var _market in marketDataJson)
            {
                // Alleen actieve markten toevoegen
                if (_market.Status != "trading")
                {
                    continue;
                }

                activeMarkets.Add(_market);
            }
        }

        return activeMarkets;
    }

    public async Task<OrderBook>? GetOrderBook(string market, int depth)
    {
        string endpoint = depth == 0
        ? "/v2/{market}/book"
        : $"/v2/{market}/book?depth={depth}";

        var orderBook = await _apiClientService.CreateGETRequest(endpoint);
        OrderBook? orderBookJson = orderBook != null ? JsonConvert.DeserializeObject<OrderBook>(orderBook) : null;
        
        if (orderBookJson != null)
        {
            return orderBookJson;
        }
        return null;
    }

    public async Task<List<Trade>> GetTrades(string market, int? limit, long? start, long? end, string? tradeIdFrom, string? tradeIdTo)
    {
        string endpoint = $"/v2/{market}/trades";

        EndpointBuilder _endpoint = new EndpointBuilder(
            endpoint,
            EndpointBuilder.ToDictionary(new
            {
                limit, start, end, tradeIdFrom, tradeIdTo 
            }));

        var _trades = await _apiClientService.CreateGETRequest(endpoint);
        var _tradesJson = JsonConvert.DeserializeObject<List<Trade>>(_trades);

        return _tradesJson;
    }

    public async Task<List<Ticker>> GetTickerPrices()
    {
        string endpoint = "/v2/ticker/price";
        string _tickerPrices= await _apiClientService.CreateGETRequest(endpoint);
        List<Ticker> _tickerPricesJson = JsonConvert.DeserializeObject<List<Ticker>>(_tickerPrices);

        return _tickerPricesJson;
    }

    public async Task<Ticker> GetTickerPrice(string market)
    {
        string endpoint = $"/v2/ticker/price?market={market}";
        string _tickerPrice = await _apiClientService.CreateGETRequest(endpoint);
        Ticker _tickerPriceJson = JsonConvert.DeserializeObject<Ticker>(_tickerPrice);

        return _tickerPriceJson;
    }

  public async Task<List<Candle>> GetCandleData(string market, string interval, int limit = 0)
  {
    string endpoint = limit == 0
    ? $"/v2/{market}/candles?interval={interval}"
    : $"/v2/{market}/candles?interval={interval}&limit={limit}";

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