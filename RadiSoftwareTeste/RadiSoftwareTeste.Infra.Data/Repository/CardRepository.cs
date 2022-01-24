using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadiSoftwareTeste.Infra.Data.Repository
{
    public class CardRepository : ICardRepository
    {
        public DataWalletConst _dataWalletConst { get; set; }

        public CardRepository()
        {
            _dataWalletConst = new DataWalletConst();
        }

        public Card GetCardBy(Guid cardId)
        {
            return _dataWalletConst.CardList.Where(x => x.CardId == cardId).FirstOrDefault();
        }

        public Card InsertCard(Card card)
        {
            _dataWalletConst.CardList.Add(card);
            return card;
        }

        public List<Card> GetAllCards()
        {
            return _dataWalletConst.CardList.ToList();
        }
    }
}
