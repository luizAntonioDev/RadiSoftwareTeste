using Microsoft.Extensions.DependencyInjection;
using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Infra.Data.Repository;

namespace RadiSoftwareTeste.Infra.CrossCutting.IoC.Modules
{
    public class DatabaseRepositoryModule
    {
        public static void Register(IServiceCollection service)
        {
            service.AddSingleton<ICardRepository>(x => new CardRepository());
            service.AddSingleton<ICustomerRepository>(x => new CustomerRepository());
            service.AddSingleton<ITokenRepository>(x => new TokenRepository());
            service.AddSingleton<IWalletRepository>(x => new WalletRepository());
        }
    }
}
