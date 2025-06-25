using System.Threading.Tasks;
using CryptoDealer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CryptoDealer.ConsoleApp
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            // DI toevoegen
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddInfrastructure(context.Configuration);
                })
                .Build();

            #region Actieve tradingbots
            DealerService<DcaStrategy> dealerDCA = host.Services.GetRequiredService<DealerService<DcaStrategy>>();
            #endregion

            #region Account acties
            // await dealer.GetAccountBalance();
            // await dealer.GetTransactionHistory();
            #endregion

            #region Market acties
            // dealer.Markets = dealer.GetMarkets().Result;
            // foreach (var market in dealer.Markets)
            // {
            //   await dealer.GetCurrentPrice(market.Market);
            // }

            // await dealer.GetOrderBook("BTC-EUR", 10);
            //await dealer.GetTrades("/v2/BTC-EUR/trades", "BTC-EUR", null, 1750438800000, 1750444130608, "0984327432", "478923055829434-03443");
            // await dealer.GetTickerPrice("BTC-EUR");
            // await dealer.GetTickerPrice(null);
            // await dealer.GetCandleData("BTC-EUR", "5m");
            // await dealer.GetCurrentPrices();
            #endregion

            #region Trading
            // await dealer.CreateOrder("SXT-EUR", "buy", "market", dealer.OperatorId, "85");
            // await dealer.GetOrder("SXT-EUR", "00000000-0000-05ef-0100-000153d37f4e");
            // await dealer.UpdateOrder(testOrder);
            // await dealer.CancelOrder(testOrder.Market, testOrder.Id);
            // await dealer.GetOpenOrders(null, null);
            // await dealer.GetTradeHistory("BTC-EUR");
            // await dealer.GetOrders("BTC-EUR");
            #endregion

            #region Transfer
            //await dealer.GetDepositData("BTC"); // NOG TESTEN
            //await dealer.GetDepositHistory("BTC");
            //await dealer.WithdrawAssets("BTC", "0.0001", ""); // NOG TESTEN
            // await dealer.GetWithdrawalHistory("BTC");
            #endregion
        }
    }
}
