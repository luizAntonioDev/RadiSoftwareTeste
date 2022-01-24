using System;

namespace RadiSoftwareTeste.Domain.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }
    }
}
