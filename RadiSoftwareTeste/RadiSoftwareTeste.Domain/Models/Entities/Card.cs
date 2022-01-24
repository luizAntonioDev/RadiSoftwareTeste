using System;

namespace RadiSoftwareTeste.Domain.Models.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public Guid CardId { get; set; }
        public string Description { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }
    }
}
