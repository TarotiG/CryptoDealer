public class DcaStrategy : StrategyType
{
  public DcaStrategy()
  {
    ExecuteTrade();
  }
  
  public override void ExecuteTrade()
  {
    Console.WriteLine("Executing DCA strategy...");
  }
}