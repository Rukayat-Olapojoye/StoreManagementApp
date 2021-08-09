using ManagementModels;
using System.Threading.Tasks;

namespace ManagementDataStore

{
    public interface ICustomerDatastore
    {
        Task<Customer> ReadCustomerFromFileAsync(Customer customerLogin);
        Task<Customer> WriteCustomerToFileAsync(Customer customer);
    }
}