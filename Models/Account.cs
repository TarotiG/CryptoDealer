/// <summary>
/// Model voor het opslaan van accountgegevens.
/// </summary>
public class Account
{
  /// <summary>
  /// Unieke identificatie van het account.
  /// </summary>
  public int AccountId { get; set; } = 1;
  /// <summary>
  /// Naam van het account.
  /// </summary>
  public string AccountName { get; set; } = "TestAccount";
  /// <summary>
  /// Balans van het account.
  /// </summary>
  [JsonProperty]
  public List<Asset> AccountBalance { get; set; } = new List<Asset>();
  /// <summary>
  /// Lijst van transacties van het account.
  /// </summary>
  [JsonProperty]
  public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}