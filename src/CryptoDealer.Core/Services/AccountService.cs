using CryptoDealer.Core.Interfaces;

public class AccountService : IAccountDataProvider
{
    private readonly IApiClient _apiClientService;

    public AccountService(IApiClient apiClientService)
    {
        _apiClientService = apiClientService;
    }

    public async Task<List<Asset>> GetAccountBalance()
    {
        var accountBalance = await _apiClientService.CreateGETRequest("/v2/balance");
        var accountBalanceJson = JsonConvert.DeserializeObject<List<Asset>>(accountBalance);
        return accountBalanceJson;
    }

    public decimal GetAvailableBalance()
    {
        return 0;
    }
  
    public decimal GetLockedBalance()
    {
        return 0;
    }
  
    public decimal GetAccountFees()
    {
        return 0;
    }
  
    public async Task<TransactionHistory> GetTransactionHistory()
    {
        var json = await _apiClientService.CreateGETRequest("/v2/account/history");
        var transactionHistory = JsonConvert.DeserializeObject<TransactionHistory>(json);
        return transactionHistory;
    }
}