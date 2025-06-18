public interface IAccountDataProvider
{
  /// <summary>
  /// Geeft de huidige balans van een account.
  /// </summary>
  Task GetAccountBalance(Account account);
  /// <summary>
  /// Geeft de beschikbare balans van een account.
  /// </summary>
  decimal GetAvailableBalance();
  /// <summary>
  /// Geeft de geblokkeerde balans van een account.
  /// </summary>
  decimal GetLockedBalance();
  /// <summary>
  /// Geeft de totale kosten van een account.
  /// </summary>
  decimal GetAccountFees();
  /// <summary>
  /// Geeft de transactiegeschiedenis van een account.
  /// </summary>
  Task GetTransactionHistory(Account account);
}