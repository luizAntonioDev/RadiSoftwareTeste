using RadiSoftwareTeste.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Domain.Interface.Repository
{
    public interface IWalletRepository
    {
        Wallet GetWalletdBy(Guid customerId);
        Wallet GetWalletdByWalletId(Guid walletId);
        Wallet CreateWallet(Wallet wallet);
        void InsertCardWallet(Wallet wallet, Card card);
        List<Wallet> GetAllWallets();
    }
}
