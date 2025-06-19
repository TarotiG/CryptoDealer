public class DealerService<TStrategy> where TStrategy : StrategyType
{
    // private readonly ApiClientService _apiClientService = new();
    private readonly AccountService _accountService = new();
    private readonly MarketDataService _marketDataService = new();
    private readonly TradingDataService _tradingDataService = new();
    public TradingStrategy<TStrategy> Strategy { get; set; }
    
    public int OperatorId { get; set; } = 5001;
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

    public async Task GetTransactionHistory(Account account)
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

    #region Trading
    public async Task<Order> GetOrder(string market, string orderId)
    {
        var order = await _tradingDataService.GetOrder(market, orderId);
        Console.WriteLine($"Id: {order.Id} - Market: {order.Market} - Status: {order.Status}");
        return order;
    }

    public async Task<Order> CreateOrder(string market, string side, string orderType, int operatorId, string amount)
    {
        var order = await _tradingDataService.CreateOrder(market, side, orderType, operatorId, amount);
        Console.WriteLine($"Order Id: {order.Id}");
        return order;
    }

    // TODO: Uitwerken met request body
    public async Task UpdateOrder(Order order)
    {
        await _tradingDataService.UpdateOrder(order);
        Console.WriteLine($"Order Id: {order.Id} has been updated.");
    }

    public async Task CancelOrder(string market, string orderId)
    {
        await _tradingDataService.CancelOrder(market, orderId);
        Console.WriteLine($"Order Id: {orderId} has been canceled.");
    }

    public async Task GetOpenOrders(string market, string _base)
    {
        List<Order> orders = await _tradingDataService.GetOpenOrders(market, _base);
        Console.WriteLine("Open orders have been retrieved.");

        foreach (var order in orders)
        {
            Console.WriteLine($"Order Id: {order.Id} - Market: {order.Market} - Status: {order.Status}");
        }
    }

    public async Task GetTradeHistory(string market)
    {
        List<Trade> trades = await _tradingDataService.GetTradeHistory(market);
        Console.WriteLine("Trade history has been retrieved.");

        foreach (var trade in trades)
        {
            Console.WriteLine($"Trade Id: {trade.Id} - Market: {trade.Market} - Side: {trade.Side}");
        }
    }

    public async Task GetOrders(string market)
    {
        List<Order> orders = await _tradingDataService.GetOrders(market);
        Console.WriteLine("Orders have been retrieved.");

        foreach (var order in orders)
        {
            Console.WriteLine($"Order Id: {order.Id} - Market: {order.Market} - Status: {order.Status}");
        }
    }

    #endregion
}