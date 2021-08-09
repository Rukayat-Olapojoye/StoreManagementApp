using ManagementDataStore;
using ManagementModels;

namespace ManagementBL
{
    public interface IStore
    {
        Store AddStore(string storeowner, string storeId, string storename, Store.StoreType storetype, int items);
        bool RemoveProducts(string storeId, int items);
        int GetNumberofProducts(string storeId);
        int AddProducts(string storeid, int items);
        // Store ShowAllStores();
    }
}

