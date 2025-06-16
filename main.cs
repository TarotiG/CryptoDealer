class Program
{
    public async static Task Main(string[] args)
    {
      Account account = new Account();
      DealerService<DcaStrategy> dealer = new DealerService<DcaStrategy>();

      // await dealer.GetAccountBalance(account);
      // await dealer.GetTradeHistory(account);
      await dealer.GetMarkets();
      await dealer.GetCurrentPrice("BTC-EUR");
      // await dealer.GetCurrentPrices();
    }
}