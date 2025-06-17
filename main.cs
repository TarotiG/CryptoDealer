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
    var Markets = dealer.GetMarkets();
    // await dealer.GetCurrentPrice("BTC-EUR");
    // await dealer.GetOrderBook("BTC-EUR");
    await dealer.GetCandleData("BTC-EUR", TimeFrame.FiveMinutes);
    // await dealer.GetCurrentPrices();
    #endregion
  }
}