using System;
using System.Threading.Tasks;

public class CryptoDealer
{
  public ClientService clientService = new();
  
  public async Task GetAccountBalance()
  {
    var AccountBalance = await clientService.CreateGETRequest("/balance/");
    Console.WriteLine(AccountBalance);
  }

  public async Task CreateOrder()
  {
    var Order = await clientService.CreatePOSTRequest("/order", "{}");
    Console.WriteLine(Order);
  }
}