using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Domain.Models.DTO.Request
{
    public class CreateWalletRequest
    {
        public Guid CustomerId { get; set; }
        public CreateWalletRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
