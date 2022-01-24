using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Domain.Models.DTO.Request
{
    public class CreateCardRequest
    {
        public Guid WalletId { get; set; }
        public string CardNumber { get; set; }
        public string Description { get; set; }
        public string CVV { get; set; }
    }
}
