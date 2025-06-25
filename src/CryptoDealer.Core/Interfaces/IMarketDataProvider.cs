public interface IMarketDataProvider
{
    /// <summary>
    /// Geeft lijst van markten.
    /// </summary>
    Task<List<MarketModel>> GetMarkets(string? market);
    /// <summary>
    /// Geeft de huidige prijs van een asset.
    /// </summary>
    Task GetCurrentPrice(string asset);
    /// <summary>
    /// Geeft de huidige prijzen van alle assets.
    /// </summary>
    Task GetCurrentPrices();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="market"></param>
    /// <returns></returns>
    Task<Ticker> GetTickerPrice(string market);
    /// <summary>
    /// Geeft de historische prijs van een asset op een bepaalde datum.
    /// </summary>
    List<decimal> GetHistoricalPrice(string asset, DateTime date);
    /// <summary>
    /// Geeft de candlesticks van een asset op een bepaald tijdsframe.
    /// </summary>
    List<decimal> GetCandles(string asset, TimeFrame timeFrame, int limit);
}