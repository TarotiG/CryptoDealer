using System.Numerics;
using System.Runtime.CompilerServices;

public class MarketDataService : IMarketDataProvider
{
  private readonly ApiClientService _apiClientService = new();

  public async Task<List<MarketModel>> GetMarkets()
  {
    List<MarketModel> _markets = new List<MarketModel>();

    var marketData = await _apiClientService.CreateGETRequest("/v2/markets");
    var marketDataJson = JsonConvert.DeserializeObject<List<MarketModel>>(marketData);

    foreach (var market in marketDataJson)
    {
      // Alleen actieve markten toevoegen
      if (market.Status != "trading")
      {
        continue;
      }
      _markets.Add(market);
    }
    return _markets;
  }

  public async Task GetOrderBook(string market, int depth)
  {
    string endpoint = depth == 0
    ? "/v2/{market}/book"
    : $"/v2/{market}/book?depth={depth}";

    var orderBook = await _apiClientService.CreateGETRequest(endpoint);
    var orderBookJson = JsonConvert.DeserializeObject<OrderBook>(orderBook);

    LogService.LogInfo($"Order book {orderBookJson.Market} is binnengehaald");
  }

  // AANPASSEN params lezer verbeteren
  public async Task GetTrades(params object[] args)
  {
    string endpoint = "";
    string market;
    int? limit;
    int? start;
    int? end;
    string tradeIdFrom;
    string tradeIdTo;

    switch (args.Length)
    {
      case 1:
        market = (string)args[0];
        endpoint = $"/v2/{market}/trades";
        break;

      case 2:
        market = (string)args[0];
        limit = (int)args[1];
        endpoint = $"/v2/{market}/trades?limit={limit}";
        break;

      case 3:
        market = (string)args[0];
        limit = (int)args[1];
        start = (int)args[2];
        endpoint = $"/v2/{market}/trades?limit={limit}&start={start}";
        break;
      case 4:
        market = (string)args[0];
        limit = (int)args[1];
        start = (int)args[2];
        end = (int)args[3];
        endpoint = $"/v2/{market}/trades?limit={limit}&start={start}&end={end}";
        break;
      case 5:
        market = (string)args[0];
        limit = (int)args[1];
        start = (int)args[2];
        end = (int)args[3];
        tradeIdFrom = (string)args[4];
        endpoint = $"/v2/{market}/trades?limit={limit}&start={start}&end={end}&tradeIdFrom={tradeIdFrom}";
        break;
      case 6:
        market = (string)args[0];
        limit = (int)args[1];
        start = (int)args[2];
        end = (int)args[3];
        tradeIdFrom = (string)args[4];
        tradeIdTo = (string)args[5];
        endpoint = $"/v2/{market}/trades?limit={limit}&start={start}&end={end}&tradeIdFrom={tradeIdFrom}&tradeIdTo={tradeIdTo}";
        break;
    }

    var _trades = await _apiClientService.CreateGETRequest(endpoint);
    var _tradesJson = JsonConvert.DeserializeObject<List<Trade>>(_trades);

    foreach (var trade in _tradesJson)
    {
      Console.WriteLine($"Id: {trade.Id} - Amount: {trade.Amount} - Price: {trade.Price}");
    }
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