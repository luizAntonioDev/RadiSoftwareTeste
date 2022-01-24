using RadiSoftwareTeste.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Domain.Interface.Repository
{
    public interface ICardRepository
    {
        Card GetCardBy(Guid cardId);
        Card InsertCard(Card card);
        List<Card> GetAllCards();

    }
}
