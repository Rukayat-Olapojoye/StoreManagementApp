using ManagementModels;
using System.Threading.Tasks;

namespace ManagementBL
{
    public interface ICustomerActions
    {
        Customer Registration(string CustomerId, string firstname, string lastname, string email, string password, string confirmPassword);
        Task<Customer> LoginAsync(string email, string password);


    }
}