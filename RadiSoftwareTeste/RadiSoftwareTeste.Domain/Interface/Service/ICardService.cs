using RadiSoftwareTeste.Domain.Models.DTO.Request;
using RadiSoftwareTeste.Domain.Models.Entities;
using System;

namespace RadiSoftwareTeste.Domain.Interface.Service
{
    public interface ICardService
    {
        Card GetCardBy(Guid cardId);
        Card InsertCard(CreateCardRequest request);
        string GetCardLast4Digits(Card card);
        int GetCVVLength(Card card);
        bool ValidateCVV(Guid cardId, string CVV);

    }
}
