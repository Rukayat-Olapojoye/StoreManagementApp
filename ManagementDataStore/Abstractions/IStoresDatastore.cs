using ManagementModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ManagementDataStore
{
    public interface IStoresDatastore
    {
        Task<Store> WriteStoreToDBAsync(Store newstore);
        Task<List<Store>> PrintAllCustomerStoresAsync(string customerId);
        Task<List<Product>> PrintStoreProductsAsync(string customerId);
        Task<int> GetNumOfStoreproductsAsync(string storeId);
        Task<bool> DeleteStoresAsync(string storeID);
        Task<bool> AddProductsToStoreAsync(string storeId, int items, string loggedIncustomer);
        Task<bool> RemoveProductsFromStoreAsync(string storeId, int items, string loggedIncustomer);






    }
}