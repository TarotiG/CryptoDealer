class Program
{
  public async static Task Main (string[] args)
  {
    DealerService<DcaStrategy> dealer = new DealerService<DcaStrategy>();
    await dealer.GetAccountBalance();
  }
}