public class TradingDataService : ITradingDataProvider
{
    private readonly ApiClientService _apiClientService = new();

    // TODO: Bitvavo support benaderen voor mijn operatorId
    public async Task<Order> CreateOrder(string body)
    {
        string endpoint = $"/v2/order";
        var order = await _apiClientService.CreatePOSTRequest(endpoint, body);
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