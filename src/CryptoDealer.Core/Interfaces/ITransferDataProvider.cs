namespace CryptoDealer.Core.Interfaces
{
    public interface ITransferDataProvider
    {
        Task<Deposit> GetDepositData(string? symbol, int? limit, long? start, long? end);
        Task<List<Deposit>> GetDepositHistory(string? symbol, int? limit, long? start, long? end);
        Task<Withdrawal> WithdrawAssets(string symbol, string amount, string address);
        Task<List<Withdrawal>> GetWithdrawalHistory(string? symbol, int? limit, long? start, long? end);
    }
}
