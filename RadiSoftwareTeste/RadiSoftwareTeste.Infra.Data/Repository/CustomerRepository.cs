using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadiSoftwareTeste.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        public DataCustomerConst _dataCustomerConst { get; set; }

        public CustomerRepository()
        {
            _dataCustomerConst = new DataCustomerConst();
        }

        public void CreateCustomer(Customer customer)
        {
            _dataCustomerConst.Customers.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _dataCustomerConst.Customers.ToList();
        }

        public Customer GetCustomerBy(Guid CustomerId)
        {
            return _dataCustomerConst.Customers.Where(x => x.CustomerId == CustomerId).FirstOrDefault();
        }
    }
}
