using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Domain.Models.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public WalletDTO Wallet { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }

    }
}
