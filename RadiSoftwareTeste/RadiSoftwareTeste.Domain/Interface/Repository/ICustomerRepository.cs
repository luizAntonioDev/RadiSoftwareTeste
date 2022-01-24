using RadiSoftwareTeste.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Domain.Interface.Repository
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomerBy(Guid CustomerId);
        List<Customer> GetAllCustomers();
    }
}
