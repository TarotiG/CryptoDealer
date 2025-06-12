public interface IMarketDataProvider
{
  /// <summary>
  /// Geeft de huidige prijs van een asset.
  /// </summary>
  decimal GetCurrentPrice(string asset);
  /// <summary>
  /// Geeft de historische prijs van een asset op een bepaalde datum.
  /// </summary>
  List<decimal> GetHistoricalPrice(string asset, DateTime date);
  /// <summary>
  /// Geeft de candlesticks van een asset op een bepaald tijdsframe.
  /// </summary>
  List<decimal> GetCandles(string asset, TimeFrame timeFrame, int limit);
}