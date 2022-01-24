using RadiSoftwareTeste.Domain.Models.Entities;
using System;

namespace RadiSoftwareTeste.Domain.Interface.Service
{
    public interface ITokenService
    {
        Token GetTokenBy(Guid tokenId);
        Token CreateToken(Card card, string last4Digits, int CVVLength);
        void ValidateToken(Guid tokenId, string last4Digits, int rotations, string tokenValue);

    }
}
