using RadiSoftwareTeste.Domain.Models.DTO;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using System;

namespace RadiSoftwareTeste.Infra.Facade.Interfaces
{
    public interface IWalletFacade
    {
        WalletDTO InsertWallet(CreateWalletRequest request);
        WalletDTO GetWalletByCustomerId(Guid customerId);
    }
}
