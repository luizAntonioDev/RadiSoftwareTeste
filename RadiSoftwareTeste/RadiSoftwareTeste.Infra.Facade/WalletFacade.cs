using Microsoft.Extensions.Configuration;
using RadiSoftwareTeste.Domain.Models.DTO;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using RadiSoftwareTeste.Infra.Facade.Enums;
using RadiSoftwareTeste.Infra.Facade.Interfaces;
using System;

namespace RadiSoftwareTeste.Infra.Facade
{
    public class WalletFacade : IWalletFacade
    {
        private readonly IConfiguration _configuration;

        public WalletFacade(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WalletDTO InsertWallet(CreateWalletRequest request)
        {
            string response = WebApi.Client("api/wallet", MethodTypeEnum.POST, _configuration, "Wallet", request);
            return WebApi.GetResponse<WalletDTO>(response);

        }

        public WalletDTO GetWalletByCustomerId(Guid customerId)
        {
            string response = WebApi.Client($"api/wallet/{customerId}", MethodTypeEnum.GET, _configuration, "Wallet");
            return WebApi.GetResponse<WalletDTO>(response);
        }

    }
}
