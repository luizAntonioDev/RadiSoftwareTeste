using RadiSoftwareTeste.Domain.Interface.Repository;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.DTO;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Utils;
using RadiSoftwareTeste.Infra.Facade.Interfaces;
using System;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IWalletFacade _walletFacade;

        public CustomerService(ICustomerRepository repository, IWalletFacade walletFacade)
        {
            _repository = repository;
            _walletFacade = walletFacade;
        }

        public CustomerDTO CreateCustomer(CreateCustomerRequest customer)
        {
            var newId = BaseUtils.NextIdList(_repository.GetAllCustomers());

            var newCustomer = new Customer()
            {
                Id = newId,
                CustomerId = Guid.NewGuid(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                BirthDate = customer.BirthDate,
                Age = BaseUtils.AgeCalculator(customer.BirthDate),
                RegistrationDate = DateTime.UtcNow,
                Status = true

            };
            _repository.CreateCustomer(newCustomer);
            var customerWallet = _walletFacade.InsertWallet(new CreateWalletRequest(newCustomer.CustomerId));

            return GetCustomerDTO(newCustomer, customerWallet);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAllCustomers();
        }

        public Customer GetCustomerBy(Guid customerId)
        {
            return _repository.GetCustomerBy(customerId);
        }

        public CustomerDTO GetCustomerWallet(Guid customerId)
        {
            var customer = _repository.GetCustomerBy(customerId);

            if (customer == null) throw new Exception("Customer does not exist.");

            var customerWallet = _walletFacade.GetWalletByCustomerId(customerId);

            return GetCustomerDTO(customer, customerWallet);
        }

        private CustomerDTO GetCustomerDTO(Customer customer, WalletDTO wallet)
        {
            return new CustomerDTO()
            {
                Id = customer.Id,
                CustomerId = customer.CustomerId,
                Age = customer.Age,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                BirthDate = customer.BirthDate,
                RegistrationDate = customer.RegistrationDate,
                Wallet = wallet,
                Status = customer.Status
            };
        }
    }
}
