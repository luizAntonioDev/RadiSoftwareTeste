using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Domain.Models.DTO.Request
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
