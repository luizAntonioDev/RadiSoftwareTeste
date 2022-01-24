using Microsoft.Extensions.Configuration;
using RadiSoftwareTeste.Domain.Models.Entities;
using RadiSoftwareTeste.Infra.Facade.Enums;
using RadiSoftwareTeste.Infra.Facade.Interfaces;
using System;

namespace RadiSoftwareTeste.Infra.Facade
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly IConfiguration _configuration;

        public CustomerFacade(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Customer GetCustomerBy(Guid CustomerId)
        {
            string response = WebApi.Client($"api/customer/{CustomerId}", MethodTypeEnum.GET, _configuration, "Customer");
            return WebApi.GetResponse<Customer>(response);
        }


    }
}
