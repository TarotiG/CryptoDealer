public class TradingDataService : ITradingDataProvider
{
    private readonly ApiClientService _apiClientService = new();

    // TODO: Later uitbreiden met meer parameters
    public async Task<Order> CreateOrder(int operatorId)
    {
        string endpoint = $"/v2/order";
        
        Order newOrder = new Order(
            Market: "SXT-EUR",
            Side: "buy",
            OrderType: "market",
            OperatorId: operatorId,
            Amount: "85"
        );

        var orderSerialized = JsonConvert.SerializeObject(newOrder);
        Console.WriteLine(orderSerialized);
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

    public async Task CancelOrder()
    {
        string endpoint = "";
        await _apiClientService.CreateGETRequest(endpoint);
    }

    public async Task UpdateOrder()
    {
        string endpoint = "";
        await _apiClientService.CreateGETRequest(endpoint);
    }

    public async Task GetOpenOrders()
    {
        string endpoint = "";
        await _apiClientService.CreateGETRequest(endpoint);
    }

    public async Task GetTradeHistory()
    {
        string endpoint = "";
        await _apiClientService.CreateGETRequest(endpoint);
    }

    public async Task GetOrders()
    {
        string endpoint = "";
        await _apiClientService.CreateGETRequest(endpoint);
    }
}