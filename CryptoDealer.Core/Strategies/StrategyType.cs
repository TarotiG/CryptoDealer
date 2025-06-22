using System;
using System.Timers;

public abstract class StrategyType
{
  public string? Name { get; set; }
  public TradeFrequency Frequency { get; set; }
  public float TradeAmount { get; set; }
  public List<string>? Assets { get; set; }
}