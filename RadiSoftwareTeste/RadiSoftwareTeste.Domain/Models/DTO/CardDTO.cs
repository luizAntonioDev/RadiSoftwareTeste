using RadiSoftwareTeste.Domain.Models.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Domain.Models.DTO
{
    public class CardDTO
    {
        public Guid CardId { get; set; }
        public string Description { get; set; }
        public TokenDTO Token { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }
    }
}
