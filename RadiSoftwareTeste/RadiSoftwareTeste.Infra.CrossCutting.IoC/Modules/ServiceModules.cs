using Microsoft.Extensions.DependencyInjection;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Infra.Facade;
using RadiSoftwareTeste.Infra.Facade.Interfaces;
using RadiSoftwareTeste.Service.Services;

namespace RadiSoftwareTeste.Infra.CrossCutting.IoC.Modules
{
    public class ServiceModules
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<ICustomerFacade, CustomerFacade>();
            service.AddScoped<IWalletFacade, WalletFacade>();


            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<ICardService, CardService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IWalletService, WalletService>();

        }
    }
}
