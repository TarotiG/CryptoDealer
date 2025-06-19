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
    // Order createdOrder = await dealer.CreateOrder("SXT-EUR", "buy", "market", dealer.OperatorId, "85");
    // Order testOrder = await dealer.GetOrder(createdOrder.Market, createdOrder.Id);
    // await dealer.UpdateOrder(testOrder);
    // await dealer.CancelOrder(testOrder.Market, testOrder.Id);
    // await dealer.GetOpenOrders(null, null);
    // await dealer.GetTradeHistory("BTC-EUR");
    // await dealer.GetOrders("BTC-EUR");
    #endregion

    #region Transfer
    await dealer.GetDepositData("BTC"); // NOG TESTEN
    // await dealer.GetDepositHistory("BTC");
    await dealer.WithdrawAssets("BTC", "0.0001", ""); // NOG TESTEN
    // await dealer.GetWithdrawalHistory("BTC");
    #endregion
  }
}