using System;

namespace RadiSoftwareTeste.Domain.Models.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public Guid TokenId { get; set; }
        public string Value { get; set; }
        public Guid CardId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Status { get; set; }
    }
}
