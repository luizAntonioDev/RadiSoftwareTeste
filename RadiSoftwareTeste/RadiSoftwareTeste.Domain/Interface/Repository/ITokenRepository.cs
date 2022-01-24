using RadiSoftwareTeste.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Domain.Interface.Repository
{
    public interface ITokenRepository
    {
        Token GetTokenBy(Guid tokenId);
        void CreateToken(Token token);
        List<Token> GetAllToken();
    }
}
