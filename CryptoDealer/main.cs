using System.Diagnostics.CodeAnalysis;

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

    // await dealer.GetOrderBook("BTC-EUR", 10);
    // await dealer.GetTrades("BTC-EUR", 10);
    // await dealer.GetTickerPrice("BTC-EUR");
    // await dealer.GetTickerPrice(null);
    // await dealer.GetCandleData("BTC-EUR", "5m");
    // await dealer.GetCurrentPrices();
    #endregion

    #region Trading
    await dealer.GetOrder("BTC-EUR", "ff403e21-e270-4584-bc9e-9c4b18461465");
    // await dealer.CreateOrder("{\r\n  \"market\": \"BTC-EUR\",\r\n  \"side\": \"buy\",\r\n  \"orderType\": \"market\",\r\n  \"operatorId\": 543462,\r\n  \"clientOrderId\": \"string\",\r\n  \"amount\": \"1.567\",\r\n  \"amountQuote\": \"5000\",\r\n  \"price\": \"6000\",\r\n  \"triggerAmount\": \"4000\",\r\n  \"triggerType\": \"price\",\r\n  \"triggerReference\": \"lastTrade\",\r\n  \"timeInForce\": \"GTC\",\r\n  \"postOnly\": false,\r\n  \"selfTradePrevention\": \"decrementAndCancel\",\r\n  \"responseRequired\": true\r\n}");
    #endregion
  }
}