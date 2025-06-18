public class DealerService<TStrategy> where TStrategy : StrategyType
{
    private readonly ApiClientService _apiClientService = new();
    private readonly AccountService _accountService = new();
    private readonly MarketDataService _marketDataService = new();
    private readonly TradingDataService _tradingDataService = new();
    public TradingStrategy<TStrategy> Strategy { get; set; }

    public List<MarketModel> Markets { get; set; } = new List<MarketModel>();
    public List<Candle> Candles { get; set; }

    public DealerService()
    {
        Strategy = new TradingStrategy<TStrategy>();
    }

    #region Account
    public async Task GetAccountBalance(Account account)
    {
        await _accountService.GetAccountBalance(account);
    }

    public async Task GetTradeHistory(Account account)
    {
        await _accountService.GetTransactionHistory(account);
    }
    #endregion

    #region Market
    public async Task<List<MarketModel>> GetMarkets()
    {
        return await _marketDataService.GetMarkets();
    }

    public async Task GetOrderBook(string market, int depth)
    {
        await _marketDataService.GetOrderBook(market, depth);
    }

    public async Task GetTrades(params object[] args)
    {
        await _marketDataService.GetTrades(args);
    }

    public async Task GetTickerPrice(string market)
    {
        await _marketDataService.GetTickerPrices(market);
    }

    public async Task GetCandleData(string market, string interval, int limit = 0)
    {
        Candles = await _marketDataService.GetCandleData(market, interval, limit);
        Console.WriteLine(Candles[0].TimeStamp);
    }
    #endregion

    public async Task GetCurrentPrice(string asset)
    {
        await _marketDataService.GetCurrentPrice(asset);
    }

    public async Task GetCurrentPrices()
    {
        await _marketDataService.GetCurrentPrices();
    }

    public async Task CreateOrder()
    {
        var Order = await _apiClientService.CreatePOSTRequest("/order", "{}");
        Console.WriteLine(Order);
    }

    #region Trading
    public async Task GetOrder(string market, string orderId)
    {
        var order = await _tradingDataService.GetOrder(market, orderId);
        Console.WriteLine(order);
    }

    #endregion
}