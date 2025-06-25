using Xunit;
using Moq;
using CryptoDealer.Core.Interfaces;
using Newtonsoft.Json;

namespace CryptoDealer.Tests.ServicesTests
{
    public class AccountServiceTests
    {
        [Fact]
        public async Task GetAccountBalance_RetrievesBalance()
        {
            // Setup Mock API Client
            var mockApiClient = new Mock<IApiClient>();

            var mockJsonResponse = JsonConvert.SerializeObject(new List<Asset>
            {
                new Asset { Symbol = "BTC", Available = "1.6346576434"},
                new Asset { Symbol = "ETH", Available = "20.2345432"}
            });

            mockApiClient.Setup(client => client.CreateGETRequest("/v2/balance")).ReturnsAsync(mockJsonResponse);

            // Test
            var mockAccountService = new AccountService(mockApiClient.Object);
            var result = await mockAccountService.GetAccountBalance();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTransactionHistory_RetrievesHistory()
        {
            // Setup Mock API Client
            var mockApiClient = new Mock<IApiClient>();

            var mockJsonResponse = JsonConvert.SerializeObject(new TransactionHistory
            {
                CurrentPage = 1,
                TotalPages = 3,
                MaxItems = 50,
                Items = new List<Transaction>
                {
                    new Transaction
                    {
                        TransactionId = "txn_123456",
                        ExecutedAt = new DateTime(2024, 12, 15, 14, 30, 0),
                        Type = "buy",
                        PriceCurrency = "EUR",
                        PriceAmount = 250.00m,
                        SentCurrency = "EUR",
                        SentAmount = 250.00m,
                        ReceivedCurrency = "BTC",
                        ReceivedAmount = 0.005m,
                        FeesCurrency = "EUR",
                        FeesAmount = 2.50m,
                        Address = "1BitcoinAddressExample123"
                    }
                }
            });

            mockApiClient.Setup(client => client.CreateGETRequest("/v2/account/history")).ReturnsAsync(mockJsonResponse);

            // Test
            var mockAccountService = new AccountService(mockApiClient.Object);
            var result = await mockAccountService.GetTransactionHistory();

            Assert.NotNull(result);
        }
    }
}
