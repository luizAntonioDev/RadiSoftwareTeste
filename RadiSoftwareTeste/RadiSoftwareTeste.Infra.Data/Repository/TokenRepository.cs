using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadiSoftwareTeste.Infra.Data.Repository
{
    public class TokenRepository : ITokenRepository
    {

        public DataWalletConst _dataWalletConst { get; set; }

        public TokenRepository()
        {
            _dataWalletConst = new DataWalletConst();
        }
  
        public Token GetTokenBy(Guid tokenId)
        {
            return _dataWalletConst.TokenList.Where(x => x.TokenId == tokenId).FirstOrDefault();
        }

        public void CreateToken(Token token)
        {
            _dataWalletConst.TokenList.Add(token);
        }

        public List<Token> GetAllToken()
        {
            return _dataWalletConst.TokenList.ToList();
        }
    }
}
