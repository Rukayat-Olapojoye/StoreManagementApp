using ManagementModels;
using System.Threading.Tasks;

namespace ManagementDataStore

{
    public interface ICustomerDatastore
    {
        Task<Customer> ReadCustomerFromDBAsync(Customer customerLogin);
        Task<Customer> WriteCustomerToDBAsync(Customer customer);
    }
}