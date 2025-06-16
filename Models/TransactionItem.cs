public class TransactionModel
{
  [JsonProperty]
  public List<TransactionItem> Items { get; set; } = new List<TransactionItem>();
}

public class TransactionItem
{
  [JsonProperty]
  public List<Transaction> Items { get; set; } = new List<Transaction>();
  public int CurrentPage { get; set; }
  public int TotalPages { get; set; }
  public int MaxItems { get; set; }
}