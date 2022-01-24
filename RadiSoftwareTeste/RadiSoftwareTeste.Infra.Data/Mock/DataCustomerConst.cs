using RadiSoftwareTeste.Domain.Models.Entities;
using System.Collections.Generic;

namespace RadiSoftwareTeste.Infra.Data.Mock
{
    public class DataCustomerConst
    {
        public  List<Customer> Customers { get; set; }
        public DataCustomerConst()
        {
            this.Customers = new List<Customer>();
        }
    }
}
