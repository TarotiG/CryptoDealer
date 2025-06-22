using System.Diagnostics;
using System.Threading;
using System.Timers;

public class DcaStrategy : StrategyType
{
    private static System.Timers.Timer _timer;
    private static decimal InvestmentAmount = 100; // bedrag per investering
    private static TimeSpan InvestmentInterval = TimeSpan.FromDays(7); // investering elke 7 dagen
    private static int TotalInvestments = 10; // bijv. 10 weken
    private static int InvestmentCount = 0;
    private static int CompletedInvestments = 0;
    private static int FailedInvestments = 0;

    public DcaStrategy()
    {
        _timer = new System.Timers.Timer(InvestmentInterval.TotalMilliseconds);
        _timer.Elapsed += ExecuteTrade;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private static void ScheduleNextInvestment()
    {
        if (InvestmentCount >= TotalInvestments)
        {
            Console.WriteLine("Every investment has completed");
            Console.WriteLine($"Total succeeded investments: {CompletedInvestments}");
        }

        _timer = new System.Timers.Timer(InvestmentInterval.TotalMilliseconds);
        _timer.Elapsed += ExecuteTrade;
        _timer.AutoReset = false; // enkel eenmaal uitvoeren
        _timer.Enabled = true;
    }

    /// <summary>
    /// Methode voor de Timer event
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    public static void ExecuteTrade(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Executing DCA strategy...");
        ExecuteDCA();
        InvestmentCount++;
        ScheduleNextInvestment();
    }

    private static void ExecuteDCA()
    {
        // In account -> account balance ophalen
        // IF balance > minimum saldo -> Get markets call
        // ELSE retry volgende dag

        // Prijzen ophalen markets -> zelf invoeren welke markets
        // Order plaatsen
        // IF alle geplande investeringen zijn uitgevoerd (success of failed) -> ScheduleNextInvestment()

    }

    // Methodes toevoegen voor analyse (winst/verlies, geslaagde orders, gefaalde orders etc.)
}