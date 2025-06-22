using CryptoDealer.Core.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class TransferDataService
{
    private readonly ApiClientService _apiClientService = new();

    public async Task<Deposit> GetDepositData(string? symbol, int? limit, long? start, long? end)
    {
        string endpoint = $"/v2/deposit?symbol={symbol}";

        EndpointBuilder _endpoint = new EndpointBuilder(
            endpoint,
            EndpointBuilder.ToDictionary(new
            {
                symbol, limit, start, end
            })
        );

        var depositData = await _apiClientService.CreateGETRequest(endpoint);
        var depositDataJson = JsonConvert.DeserializeObject<Deposit>(depositData);
        return depositDataJson;
    }

    public async Task<List<Deposit>> GetDepositHistory(string? symbol, int? limit, long? start, long? end)
    {
        string endpoint = $"/v2/depositHistory";

        EndpointBuilder _endpoint = new EndpointBuilder(
            endpoint,
            EndpointBuilder.ToDictionary(new
            { 
                symbol, limit, start, end
            })
        );

        var depositData = await _apiClientService.CreateGETRequest(endpoint);
        var depositDataJson = JsonConvert.DeserializeObject<List<Deposit>>(depositData);
        return depositDataJson;
    }

    public async Task<Withdrawal> WithdrawAssets(string symbol, string amount, string address)
    {
        string endpoint = "/v2/withdrawal";
      
        Withdrawal withdrawal = new Withdrawal(
            Symbol: symbol,
            Amount: amount,
            Address: address
        );
      
        var withdrawalSerialized = JsonConvert.SerializeObject(withdrawal);
        var withdrawalData = await _apiClientService.CreatePOSTRequest(endpoint, withdrawalSerialized);
        var withdrawalDataJson = JsonConvert.DeserializeObject<Withdrawal>(withdrawalData);
      
        return withdrawalDataJson;
    }

    public async Task<List<Withdrawal>> GetWithdrawalHistory(string? symbol, int? limit, long? start, long? end)
    {
      string endpoint = $"/v2/withdrawalHistory";

        EndpointBuilder _endpoint = new EndpointBuilder(
            endpoint,
            EndpointBuilder.ToDictionary(new
            {
                symbol, limit, start, end
            })
        );

        var withdrawalData = await _apiClientService.CreateGETRequest(endpoint);
      var withdrawalDataJson = JsonConvert.DeserializeObject<List<Withdrawal>>(withdrawalData);
      
      return withdrawalDataJson;
    }
}