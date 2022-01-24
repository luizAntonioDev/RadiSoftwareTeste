using RadiSoftwareTeste.Domain.Models.Entities;
using System;

namespace RadiSoftwareTeste.Infra.Facade.Interfaces
{
    public interface ICustomerFacade
    {
        Customer GetCustomerBy(Guid CustomerId);
    }
}
