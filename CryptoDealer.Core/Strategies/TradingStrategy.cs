/// <summary>
/// Bevat de constructor die een instantie maakt van de TStrategy voor de trading bot.
/// </summary>
/// <typeparam name="TStrategy"></typeparam>
public class TradingStrategy<TStrategy> where TStrategy : StrategyType
{
    public TradingStrategy()
    {
        Activator.CreateInstance<TStrategy>();
    }
}