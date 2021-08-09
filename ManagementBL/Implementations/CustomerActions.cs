using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;

namespace ManagementBL
{
    public class CustomerActions : ICustomerActions
    {
        private readonly ICustomerDatastore customerdataStore;
        public CustomerActions(ICustomerDatastore dataStore)
        {
            customerdataStore = dataStore;
        }

        public Customer Registration(string customerid, string firstname, string lastname, string email, string password, string confirmPassword)
        {
            Customer customer = new Customer
            {
                CustomerID = customerid,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,

            };
            //Writing user to file
            customerdataStore.WriteCustomerToFileAsync(customer);
            return customer;
        }

        public async Task<Customer> LoginAsync(string email, string password)
        {
            Customer customerlogin = new Customer
            {
                Email = email,
                Password = password,
            };
            var customerfound = await customerdataStore.ReadCustomerFromFileAsync(customerlogin);
            if (customerfound == null)
            {
                throw new System.Exception("Customer not found");
            }
            return customerfound;
        }


    }
}