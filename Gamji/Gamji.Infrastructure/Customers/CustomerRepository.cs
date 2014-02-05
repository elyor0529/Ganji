using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamji.Core.Interfaces;
using Gamji.Core.Models;

namespace Gamji.Infrastructure.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int id)
        {
            return new Customer
                {
                    FirstName = "Rod",
                    LastName = "Johnson"
                };
        }
    }
}
