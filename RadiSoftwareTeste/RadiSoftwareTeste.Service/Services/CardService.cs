using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Security;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Utils;
using System;
using System.Linq;


namespace RadiSoftwareTeste.Service.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public Card GetCardBy(Guid cardId)
        {
            return _cardRepository.GetCardBy(cardId);
        }

        public Card InsertCard(CreateCardRequest request)
        {
            CardValidation(request);
            var newId = BaseUtils.NextIdList<Card>(_cardRepository.GetAllCards());
            var newCard = _cardRepository.InsertCard(new Card()
            {
                Id = newId,
                CardId = Guid.NewGuid(),
                CardNumber = Crypt.Encrypt(request.CardNumber, true),
                CVV = Crypt.Encrypt(request.CVV, true),
                Description = request.Description,
                RegistrationDate = DateTime.UtcNow,
                Status = true
            });

            return newCard;

        }

        private void CardValidation(CreateCardRequest request)
        {
            if (string.IsNullOrEmpty(request.CardNumber)) throw new Exception("Enter the Credit Card Number");
            if (string.IsNullOrEmpty(request.CVV)) throw new Exception("Enter the CVV Number.");

            if (!request.CardNumber.All(char.IsNumber)) throw new Exception("Credit Card Number in the wrong format.");

            if (request.CardNumber.Length != 16)
                throw new Exception("Invalid Credit Card Number");

            if (!request.CVV.All(char.IsNumber)) throw new Exception("CVV in the wrong format");

            if (request.CVV.Length < 3 || request.CVV.Length > 5)
                throw new Exception("Invalid CVV Number.");
        }

        public string GetCardLast4Digits(Card card)
        {
            var cardNumer = Crypt.Decrypt(card.CardNumber, true);

            return cardNumer.Substring(12, 4);
        }

        public int GetCVVLength(Card card)
        {
            var CVV = Crypt.Decrypt(card.CVV, true);
            return CVV.Length;
        }

        public bool ValidateCVV(Guid cardId, string CVV)
        {
            var card = _cardRepository.GetCardBy(cardId);
            var cardCVV = Crypt.Decrypt(card.CVV, true);

            if (CVV != cardCVV) return false;

            return true;
        }
    }
}
