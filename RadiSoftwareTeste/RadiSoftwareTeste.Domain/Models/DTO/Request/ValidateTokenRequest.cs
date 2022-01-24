using System;

namespace RadiSoftwareTeste.Domain.Models.DTO.Request
{
    public class ValidateTokenRequest
    {
        public Guid WalletId { get; set; }
        public Guid CardId { get; set; }
        public Guid TokenId { get; set; }
        public string Token { get; set; }
        public string CVV { get; set; }

    }
}
