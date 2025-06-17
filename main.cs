class Program
{
  public async static Task Main(string[] args)
  {
    Account account = new Account();
    DealerService<DcaStrategy> dealer = new DealerService<DcaStrategy>();

    #region Account acties
    // await dealer.GetAccountBalance(account);
    // await dealer.GetTradeHistory(account);
    #endregion

    #region Market acties
    // dealer.Markets = dealer.GetMarkets().Result;
    // foreach (var market in dealer.Markets)
    // {
    //   await dealer.GetCurrentPrice(market.Market);
    // }

    // await dealer.GetOrderBook("BTC-EUR");
    await dealer.GetCandleData("BTC-EUR", "5m");
    // await dealer.GetCurrentPrices();
    #endregion
  }
}