using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Utils;
using System;
using System.Linq;

namespace RadiSoftwareTeste.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _repository;

        public TokenService(ITokenRepository repository)
        {
            _repository = repository;
        }

        public Token CreateToken(Card card, string last4Digits, int CVVLength)
        {


            var token = GenerateToken(last4Digits, CVVLength);
            var newId = BaseUtils.NextIdList<Token>(_repository.GetAllToken());
            var newToken = new Token()
            {
                Id = newId,
                TokenId = Guid.NewGuid(),
                CardId = card.CardId,
                Value = token,
                RegistrationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                Status = true
            };

            _repository.CreateToken(newToken);
            return newToken;

        }

        public string GenerateToken(string last4Digits, int rotations)
        {
            var listNumbers = last4Digits.ToCharArray().ToList();

            for (int i = 0; i < rotations; i++)
            {
                var last = listNumbers.Last();
                listNumbers.Insert(0, last);
                listNumbers.RemoveAt(listNumbers.Count() - 1);
            }

            return string.Join("", listNumbers);

        }
        public Token GetTokenBy(Guid tokenId)
        {
            return _repository.GetTokenBy(tokenId);
        }

        public void ValidateToken(Guid tokenId, string last4Digits, int rotations, string tokenValue)
        {
            var token = _repository.GetTokenBy(tokenId);

            if (token == null) throw new Exception("Token does not exist.");

            if (DateTime.UtcNow > token.ExpirationDate) throw new Exception("Expired Token.");

            var tokenGerado = GenerateToken(last4Digits, rotations);
            if (tokenGerado != tokenValue) throw new Exception("Invalid Token.");

        }

    }
}
