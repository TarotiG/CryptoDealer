public class AccountService : IAccountDataProvider
{
  private readonly ApiClientService _apiClientService = new();
  
  public async Task GetAccountBalance(Account _account)
  {
    var Data = await _apiClientService.CreateGETRequest("/v2/balance");
    foreach (var asset in JsonConvert.DeserializeObject<List<Asset>>(Data))
    {
      _account.AccountBalance.Add(asset);
    }

    foreach (var asset in _account.AccountBalance)
    {
      Console.WriteLine($"Asset: {asset.Symbol} - \tAvailable: {asset.Available} - InOrder: {asset.InOrder}");
    }
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
  
  public async Task GetTransactionHistory(Account _account)
  {
    var transactionData = await _apiClientService.CreateGETRequest("/v2/account/history");
    var JsonTransactieData = JsonConvert.DeserializeObject<TransactionItem>(transactionData);

    foreach (var item in JsonTransactieData.Items)
    {
      Console.WriteLine($"Adding transaction: {item.TransactionId}");
      _account.Transactions.Add(item);
    }
  }
}