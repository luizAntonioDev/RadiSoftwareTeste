using System;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Domain.Models.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public Guid WalletId { get; set; }
        public Customer Customer { get; set; }
        public List<Card> Cards { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }

        public Wallet()
        {
            Cards = new List<Card>();
        }
    }
}
