public class DealerService<TStrategy> where TStrategy : StrategyType
{
    public ApiClientService apiClientService = new();
    public TradingStrategy<TStrategy> Strategy { get; set; }

    public DealerService()
    {
        Strategy = new TradingStrategy<TStrategy>();
    }

    public async Task GetAccountBalance()
    {
        var AccountBalance = await apiClientService.CreateGETRequest("/v2/balance");
        LogService.LogInfo(AccountBalance);
    }

    public async Task CreateOrder()
    {
        var Order = await apiClientService.CreatePOSTRequest("/order", "{}");
        Console.WriteLine(Order);
    }
}