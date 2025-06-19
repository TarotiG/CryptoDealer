public interface ITradingDataProvider
{
    /// <summary>
    /// Returnt informatie over een bestaande order
    /// </summary>
    Task<Order> GetOrder(string market, string orderId);
    /// <summary>
    /// Returnt een lijst met open orders
    /// </summary>
    Task<List<Order>> GetOpenOrders(string market, string _base);
    /// <summary>
    /// Returnt de trade history van een market
    /// </summary>
    Task<List<Trade>> GetTradeHistory(string market);
    /// <summary>
    /// Returnt een lijst met orders
    /// </summary>
    Task<List<Order>> GetOrders(string market);
}