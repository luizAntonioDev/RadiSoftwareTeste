using System;

namespace RadiSoftwareTeste.Domain.Models.DTO.Request
{
    public class CreateTokenRequest
    {
        public int WalletId { get; set; }
        public Guid CardId { get; set; }
        public Guid Token { get; set; }
        public int Cvv { get; set; }

    }
}
