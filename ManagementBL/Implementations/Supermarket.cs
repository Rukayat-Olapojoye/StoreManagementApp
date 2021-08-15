using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;
namespace ManagementBL
{
    public class Supermarket : IStore
    {

        private readonly IStoresDatastore _storedata;
        public Supermarket(IStoresDatastore storedata)
        {
            _storedata = storedata;
        }

        public async Task<Store> AddStoreAsync(string storeowner, string storeId, string storename, Store.StoreType storetype, int items)
        {
            Store supermarket = new Store
            {
                StoreOwner = storeowner,
                StoreID = storeId,
                StoreName = storename,
                TypeOfStore = storetype,
                NumofProducts = items,
            };
            // Writing store to file
            var addedStore = await _storedata.WriteStoreToDBAsync(supermarket);
            return addedStore;
        }

        //Yet to implement this*****
        public bool AddProducts(string storeId, int numofItems,string loggedIncustomer)
        {

            return _storedata.AddProductsToStoreAsync(storeId, numofItems, loggedIncustomer).Result;
        }

        public bool RemoveProducts(string storeId, int numofItems,string loggedIncustomer)
        {
            
            return _storedata.RemoveProductsFromStoreAsync(storeId, numofItems, loggedIncustomer).Result;
        }

        public int GetNumberofProducts(string storeid)
        {
            return _storedata.GetNumOfStoreproductsAsync(storeid).Result;
        }
        public Task<bool> DeleteStore(string storeID)
        {
            return _storedata.DeleteStores(storeID);
        }

    }
}