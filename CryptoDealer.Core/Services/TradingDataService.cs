public class TradingDataService : ITradingDataProvider
{
    private readonly ApiClientService _apiClientService = new();

    // TODO: Later uitbreiden met meer parameters
    public async Task<Order> CreateOrder(string market, string side, string orderType, int operatorId, string amount)
    {
        string endpoint = $"/v2/order";
        
        Order newOrder = new Order(
            Market: market,
            Side: side,
            OrderType: orderType,
            OperatorId: operatorId,
            Amount: amount
        );

        var orderSerialized = JsonConvert.SerializeObject(newOrder);
        //Console.WriteLine(orderSerialized);
        var order = await _apiClientService.CreatePOSTRequest(endpoint, orderSerialized);
        var orderJson = JsonConvert.DeserializeObject<Order>(order);

        return orderJson;
    }

    public async Task<Order> GetOrder(string market, string orderId)
    {
        string endpoint = $"/v2/order?market={market}&orderId={orderId}";
        var order = await _apiClientService.CreateGETRequest(endpoint);
        var orderJson = JsonConvert.DeserializeObject<Order>(order);

        return orderJson;
    }

    public async Task<Order> CancelOrder(string market, string orderId)
    {
        string endpoint = $"/v2/order?market={market}&orderId={orderId}";
        var canceledOrder = await _apiClientService.CreateDELETERequest(endpoint);
        var canceledOrderJson = JsonConvert.DeserializeObject<Order>(canceledOrder);
        return canceledOrderJson;
    }

    // TODO: Uitwerken met request body
    public async Task<Order> UpdateOrder(Order order)
    {
        string endpoint = "/v2/order";
        var orderSerialized = JsonConvert.SerializeObject(order);
        
        var updatedOrder = await _apiClientService.CreatePUTRequest(endpoint, orderSerialized);
        var updatedOrderJson = JsonConvert.DeserializeObject<Order>(updatedOrder);

        return updatedOrderJson;
    }

    public async Task<List<Order>> GetOpenOrders(string market, string _base)
    {
        string endpoint;

        if (string.IsNullOrEmpty(market) && string.IsNullOrEmpty(_base))
        {
            endpoint = "/v2/ordersOpen";
        }
        else if(string.IsNullOrEmpty(market))
        {
            endpoint = $"/v2/ordersOpen?base={_base}";
        }
        else if(string.IsNullOrEmpty(_base))
        {
            endpoint = $"/v2/ordersOpen?market={market}";
        }
        else
        {
            endpoint = $"/v2/ordersOpen?market={market}&base={_base}";
        }
        
        var openOrders = await _apiClientService.CreateGETRequest(endpoint);
        var openOrdersJson = JsonConvert.DeserializeObject<List<Order>>(openOrders);
        return openOrdersJson;
    }

    // TODO: Uitwerken met parameters
    public async Task<List<Trade>> GetTradeHistory(string market)
    {
        string endpoint = $"/v2/trades?market={market}";
        var trades = await _apiClientService.CreateGETRequest(endpoint);
        var tradesJson = JsonConvert.DeserializeObject<List<Trade>>(trades);
        return tradesJson;
    }

    // TODO: Uitwerken met parameters
    public async Task<List<Order>> GetOrders(string market)
    {
        string endpoint = $"/v2/orders?market={market}";
        var orders = await _apiClientService.CreateGETRequest(endpoint);
        var ordersJson = JsonConvert.DeserializeObject<List<Order>>(orders);
        return ordersJson;
    }
}