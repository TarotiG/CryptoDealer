using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CryptoDealer.Core.Interfaces;
//using CryptoDealer.Infrastructure.Persistence;

namespace CryptoDealer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Db registreren aan DI -> LATER UITWERKEN
            //var connectionString = configuration.GetConnectionString("");
            //services.AddDbContext<>(options);

            // Services registreren
            services.AddSingleton<IApiClient, ApiClientService>();
            services.AddSingleton<IAccountDataProvider, AccountService>();
            services.AddSingleton<IMarketDataProvider, MarketDataService>();
            services.AddSingleton<ITradingDataProvider, TradingDataService>();
            services.AddSingleton<ITransferDataProvider, TransferDataService>();

            // Strategieen registreren
            services.AddTransient<DcaStrategy>();
            services.AddTransient(typeof(DealerService<>));


            return services;
        }
    }
}
