using System.Diagnostics.CodeAnalysis;

class Program
{
  public async static Task Main(string[] args)
  {
    Account account = new Account();
    DealerService<DcaStrategy> dealer = new DealerService<DcaStrategy>();

    #region Account acties
    // await dealer.GetAccountBalance(account);
    // await dealer.GetTransactionHistory(account);
    #endregion

    #region Market acties
    // dealer.Markets = dealer.GetMarkets().Result;
    // foreach (var market in dealer.Markets)
    // {
    //   await dealer.GetCurrentPrice(market.Market);
    // }

    // await dealer.GetOrderBook("BTC-EUR", 10);
    // await dealer.GetTrades("BTC-EUR", 10);
    // await dealer.GetTickerPrice("BTC-EUR");
    // await dealer.GetTickerPrice(null);
    // await dealer.GetCandleData("BTC-EUR", "5m");
    // await dealer.GetCurrentPrices();
    #endregion

    #region Trading
    // await dealer.CreateOrder(dealer.OperatorId);
    await dealer.GetOrder("SXT-EUR", "00000000-0000-05ef-0100-00015333174d");
    #endregion
  }
}