using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Domain.Models.DTO.Response
{
    public class CreateCardResponse
    {
        public Guid WalletId { get; set; }
        public Guid CardId { get; set; }
        public Guid TokenId { get; set; }
        public string Token { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
