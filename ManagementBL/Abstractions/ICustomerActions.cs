using ManagementModels;
using System.Threading.Tasks;

namespace ManagementBL
{
    public interface ICustomerActions
    {
        Task<Customer> RegistrationAsync(string CustomerId, string firstname, string lastname, string email, string password, string confirmPassword);
        Task<Customer> LoginAsync(string email, string password);


    }
}