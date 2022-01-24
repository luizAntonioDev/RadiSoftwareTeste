using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadiSoftwareTeste.Infra.Data.Repository
{
    public class WalletRepository : IWalletRepository
    {
        public DataWalletConst _dataWalletConst { get; set; }

        public WalletRepository()
        {
            _dataWalletConst = new DataWalletConst();
        }

        public Wallet CreateWallet(Wallet wallet)
        {
            _dataWalletConst.WalletList.Add(wallet);
            return wallet;
        }

        public Wallet GetWalletdBy(Guid customerId)
        {
            return _dataWalletConst.WalletList.Where(x => x.Customer.CustomerId == customerId).FirstOrDefault();
        }
        public List<Wallet> GetAllWallets()
        {
            return _dataWalletConst.WalletList.ToList();
        }

        public void InsertCardWallet(Wallet wallet, Card card)
        {
            wallet.Cards.Add(card);

        }

        public Wallet GetWalletdByWalletId(Guid walletId)
        {
            return _dataWalletConst.WalletList.Where(x => x.WalletId == walletId).FirstOrDefault();
        }
    }
}
