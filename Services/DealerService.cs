public class DealerService<TStrategy> where TStrategy : StrategyType
{
    private readonly ApiClientService apiClientService = new();
    private readonly AccountService _accountService;
    public TradingStrategy<TStrategy> Strategy { get; set; }

    public DealerService()
    {
        Strategy = new TradingStrategy<TStrategy>();
        _accountService = new();
    }

    public async Task GetAccountBalance(Account account)
    {
        await _accountService.GetAccountBalance(account);
    }

    public async Task GetTradeHistory(Account account)
    {
        await _accountService.GetTradeHistory(account);
    }

    public async Task CreateOrder()
    {
        var Order = await apiClientService.CreatePOSTRequest("/order", "{}");
        Console.WriteLine(Order);
    }
}