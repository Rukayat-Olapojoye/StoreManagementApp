using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementModels;
using Microsoft.EntityFrameworkCore;

namespace ManagementDataStore
{
   public  class EFCORECustomer : ICustomerDatastore
    {

        public async Task<Customer> ReadCustomerFromDBAsync(Customer customerLogin)

        {
            using (StoreDBContext context = new StoreDBContext())
            {
                Customer customer = await context.Customers
                    .FirstOrDefaultAsync(customer => customer.Email == customerLogin.Email && customer.Password == customerLogin.Password);
                return customer;
            }
        }

        public async Task<Customer> WriteCustomerToDBAsync(Customer customer)
        {
            using (StoreDBContext context = new StoreDBContext())
            {
                await context.Customers.AddAsync(customer);
                var result = await context.SaveChangesAsync();

                return customer;
            }

        }
    }

}
