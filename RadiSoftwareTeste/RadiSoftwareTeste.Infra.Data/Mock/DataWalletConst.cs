using RadiSoftwareTeste.Domain.Models.Entities;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Infra.Data.Mock
{
    public class DataWalletConst
    {
        public List<Wallet> WalletList { get; set; }
        public List<Card> CardList { get; set; }
        public List<Token> TokenList { get; set; }

        public DataWalletConst()
        {
            this.WalletList = new List<Wallet>();
            this.CardList = new List<Card>();
            this.TokenList = new List<Token>();
        }
    }
}
