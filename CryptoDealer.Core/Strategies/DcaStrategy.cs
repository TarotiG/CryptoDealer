using System.Threading;
using System.Timers;
using CryptoDealer.Core.Models;

public class DcaStrategy : StrategyType
{
    private readonly AccountService _accountService = new();
    private readonly MarketDataService _marketDataService = new();
    private readonly TradingDataService _tradingDataService = new();

    private static System.Timers.Timer _timer;
    private static ManualResetEvent resetEvent = new ManualResetEvent(false);  

    private static decimal InvestmentAmount = 100; // bedrag per investering
    private static TimeSpan InvestmentInterval = TimeSpan.FromDays(7); // investering elke 7 dagen
    private static int TotalInvestments = 10; // bijv. 10 weken
    private static int InvestmentCount = 0;
    private static int CompletedInvestments = 0;
    private static int FailedInvestments = 0;
    private List<Investment> Investments = new List<Investment>();

    public DcaStrategy()
    {
        //_timer = new System.Timers.Timer(InvestmentInterval.TotalMilliseconds);
        _timer = new System.Timers.Timer(500);
        _timer.Elapsed += ExecuteTrade;
        _timer.AutoReset = true;
        _timer.Start();

        Console.WriteLine("Executing DCA strategy for trading...");
        resetEvent.WaitOne();
    }

    /// <summary>
    /// Methode voor de Timer event
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    public void ExecuteTrade(Object? source, System.Timers.ElapsedEventArgs e)
    {
        if (InvestmentCount >= TotalInvestments)
        {
            Console.WriteLine("All investments have been executed.\n");
            Console.WriteLine($"Total completed investments: {CompletedInvestments}");
            _timer.Stop();
            resetEvent.Set();
        }

        try
        {
            ExecuteDCA();
            CompletedInvestments++;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong with investment {Investments.Last().InvestmentId}");
            FailedInvestments++;
        }

        InvestmentCount++;
    }

    private void ExecuteDCA()
    {
        // In account -> account balance ophalen
        List<Asset> balance = _accountService.GetAccountBalance().Result;

        Console.WriteLine($"Current balance: ");
        foreach (var item in balance)
        {
            Console.WriteLine($"Asset: {item.Symbol} - Available: {item.Available}");
        }

        // Als er genoeg saldo in euro's is --> nieuwe investment aanmaken
        Asset? assetEUR = balance.FirstOrDefault<Asset>(item => item.Symbol == "EUR");
        decimal balanceEUR = decimal.Parse(assetEUR.Available, CultureInfo.InvariantCulture);

        if (balanceEUR > 25)
        {
            Investments.Add(new Investment());
            Console.WriteLine($"New Investment {Investments.Last().InvestmentId} has been created.");

            // IF Investments.Count > 0 -> Get ticket price call for selected market (voor nu alleen BTC-EUR of ETH-EUR)
            if (Investments.Count > 0)
            {
                Ticker tickerPrice = _marketDataService.GetTickerPrice("BTC-EUR").Result;
                Console.WriteLine($"Market: {tickerPrice.Market} - Price: {decimal.Parse(tickerPrice.Price, CultureInfo.InvariantCulture)}");
            }

            // Order aanmaken en in investment zetten voor latere logging - NIET ZOMAAR UITVOEREN, ORDER GAAT DAADWERKELIJK GEPLAATST WORDEN
            Order order = _tradingDataService.CreateOrder("SXT-EUR", "buy", "market", 5001, "85").Result; // Verder uitzoeken hoe en waar ik operatorId ga genereren en plaatsen. Voor nu: 5001
            if (order.Id != null)
            {
                Investments.Last().Orders.Add(order);
            }
        }
        else
        {
            Console.WriteLine($"No new investment has been made this week.\n[Reason] - Insufficient balance\nCurrent balance: {balanceEUR}");
        }
    }

    // Methodes toevoegen voor analyse (winst/verlies, geslaagde orders, gefaalde orders etc.)
}