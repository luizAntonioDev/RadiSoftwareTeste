using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Domain.Models.DTO
{
    public class WalletDTO
    {
        public int Id { get; set; }
        public Guid WalletId { get; set; }
        public List<CardDTO> Cards { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }
    }
}
