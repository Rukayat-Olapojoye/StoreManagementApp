using ManagementDataStore;
using ManagementModels;
using System.Threading.Tasks;

namespace ManagementBL
{
    public interface IStore
    {
        Task<Store> AddStoreAsync(string storeowner, string storeId, string storename, Store.StoreType storetype, int items);
        bool RemoveProducts(string storeId, int items, string loggedIncustomer);
        int GetNumberofProducts(string storeId);
        bool AddProducts(string storeid, int items, string loggedcustomer);
        Task<bool> DeleteStore(string storeID);
        // Store ShowAllStores();
    }
}

