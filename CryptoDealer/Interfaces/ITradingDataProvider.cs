public interface ITradingDataProvider
{
    /// <summary>
    /// Returnt informatie over een bestaande order
    /// </summary>
    Task<Order> GetOrder(string market, string orderId);
    /// <summary>
    /// 
    /// </summary>
    Task GetOpenOrders();
    /// <summary>
    /// 
    /// </summary>
    Task GetTradeHistory();
    /// <summary>
    /// 
    /// </summary>
    Task GetOrders();
}