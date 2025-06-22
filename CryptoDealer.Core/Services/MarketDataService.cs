using CryptoDealer.Core.Models;

public class MarketDataService : IMarketDataProvider
{
    private readonly ApiClientService _apiClientService = new();

    public async Task<List<MarketModel>> GetMarkets()
    {
        List<MarketModel> _markets = new List<MarketModel>();

        var marketData = await _apiClientService.CreateGETRequest("/v2/markets");
        List<MarketModel>? marketDataJson = JsonConvert.DeserializeObject<List<MarketModel>>(marketData);
    
        if (marketDataJson != null && marketDataJson.Count > 0)
        {
            foreach (var market in marketDataJson)
            {
                // Alleen actieve markten toevoegen
                if (market.Status != "trading")
                {
                    continue;
                }

                _markets.Add(market);
            }
        }

        return _markets;
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

    public async Task<List<Trade>> GetTrades(RequestParams _params)
    {
        string? endpoint = null;
        string market = "";
        var properties = typeof(RequestParams).GetProperties();

        List<string> queryParams = new();

        foreach (var property in properties)
        {
            var value = property.GetValue(_params);
            if (value == null)
                continue;

            string propName = property.Name.ToLower();

            if (propName == "market")
            {
                market = value.ToString();
                endpoint = $"/v2/{market}/trades";
                continue;
            }

            if (propName == "endpoint")
                continue;

            queryParams.Add($"{propName}={value}");
        }

        if (queryParams.Count > 0)
        {
            endpoint += "?" + string.Join("&", queryParams);
        }

        Console.WriteLine(endpoint);

        var _trades = await _apiClientService.CreateGETRequest(endpoint);
        var _tradesJson = JsonConvert.DeserializeObject<List<Trade>>(_trades);

        return _tradesJson;
    }

    public async Task GetTickerPrices(string market)
  {
    string endpoint = "";
    string _tickerPrice;
    List<Ticker> _tickerPricesJson;
    Ticker _tickerPriceJson;

    if (string.IsNullOrEmpty(market))
    {
      endpoint = "/v2/ticker/price";
      _tickerPrice = await _apiClientService.CreateGETRequest(endpoint);
      _tickerPricesJson = JsonConvert.DeserializeObject<List<Ticker>>(_tickerPrice);

      foreach (var ticker in _tickerPricesJson)
      {
        Console.WriteLine($"Market: {ticker.Market} - Price: {ticker.Price}");
      }
    }
    else
    {
      endpoint = $"/v2/ticker/price?market={market}";
      _tickerPrice = await _apiClientService.CreateGETRequest(endpoint);
      _tickerPriceJson = JsonConvert.DeserializeObject<Ticker>(_tickerPrice);

      Console.WriteLine($"Market: {_tickerPriceJson.Market} - Price: {_tickerPriceJson.Price}");
    }
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