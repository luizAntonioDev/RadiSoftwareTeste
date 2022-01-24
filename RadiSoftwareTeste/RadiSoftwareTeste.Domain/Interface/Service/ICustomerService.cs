using RadiSoftwareTeste.Domain.Models.DTO;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using RadiSoftwareTeste.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Domain.Interface.Service
{
    public interface ICustomerService
    {
        CustomerDTO CreateCustomer(CreateCustomerRequest customer);
        Customer GetCustomerBy(Guid customerId);
        List<Customer> GetAllCustomers();
        CustomerDTO GetCustomerWallet(Guid customerId);

    }
}
