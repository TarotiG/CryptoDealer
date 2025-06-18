public class TradingStrategy<TStrategy> where TStrategy : StrategyType
{
  private readonly TStrategy _strategy;

  public TradingStrategy()
  {
    _strategy = Activator.CreateInstance<TStrategy>();
  }

  public void Run()
  {
    _strategy.ExecuteTrade();
  }
}