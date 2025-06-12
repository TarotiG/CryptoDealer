public class DealerService<TStrategy> where TStrategy : StrategyType
{
    public ClientService clientService = new();
    public TradingStrategy<TStrategy> Strategy { get; set; }

    public DealerService()
    {
        Strategy = new TradingStrategy<TStrategy>();
    }

    public async Task GetAccountBalance()
    {
        var AccountBalance = await clientService.CreateGETRequest("/balance");
        Console.WriteLine(AccountBalance);
    }

    public async Task CreateOrder()
    {
        var Order = await clientService.CreatePOSTRequest("/order", "{}");
        Console.WriteLine(Order);
    }
}