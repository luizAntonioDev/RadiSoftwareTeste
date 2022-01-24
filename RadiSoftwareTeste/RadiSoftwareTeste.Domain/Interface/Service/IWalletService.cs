using RadiSoftwareTeste.Domain.Models.DTO;
using RadiSoftwareTeste.Domain.Models.DTO.Response;
using RadiSoftwareTeste.Domain.Models.Entities;
using System;

namespace RadiSoftwareTeste.Domain.Interface.Service
{
    public interface IWalletService
    {
        WalletDTO GetWalletdBy(Guid customerId);
        WalletDTO GetWalletdByWalletId(Guid walletId);
        WalletDTO CreateWallet(Guid customerId);
        CreateCardResponse InsertCard(Guid walletId, Card card, Guid tokenId, string token);

    }
}
