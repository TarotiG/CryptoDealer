using System;
using System.Threading.Tasks;

class Program
{
  public async static Task Main (string[] args)
  {
    CryptoDealer dealer = new();
    await dealer.GetAccountBalance();
  }
}