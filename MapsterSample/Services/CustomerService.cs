using Mapster;
using MapsterSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsterSample.Services
{
    internal class CustomerService : ICustomerService
    {
        IEnumerable<Customer> customers = new List<Customer>()
            {
                new Customer(){
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    City = "Gotham City",
                    Order = new Order() { Id = 1, ItemName="Cape", ItemColor=Color.Black}
                },
                new Customer(){
                    Id = 2,
                    FirstName = "Clark",
                    LastName = "Kent",
                    City = "Crypton",
                    Order = new Order() { Id = 2, ItemName="Cape", ItemColor=Color.Red}
                }
            };

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return customers.Select(c => c.Adapt<CustomerDto>());
        }

        public IEnumerable<CustomerDto> AddCustomer(CustomerDto customerDto)
        {
            customers = customers.Append(customerDto.Adapt<Customer>());

            return GetCustomers();
        }
    }
}
