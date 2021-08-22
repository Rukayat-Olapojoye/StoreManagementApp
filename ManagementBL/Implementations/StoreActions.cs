using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace ManagementBL
{
    public class StoreActions : IStore
    {

        private readonly IStoresDatastore _storedata;
        public StoreActions (IStoresDatastore storedata)
        {
            _storedata = storedata;
        }

        public async Task<Store> AddStoreAsync(string storeowner, string storeId, string storename, Store.StoreType storetype, int items)
        {
            Store supermarket = new Store
            {
                customersId = storeowner,
                Id = storeId,
                StoreName = storename,
                TypeOfStore = storetype,
                NumofProducts = items,
            };
            // Writing store to db
            var addedStore = await _storedata.WriteStoreToDBAsync(supermarket);
            return addedStore;
        }

       
        public bool AddProducts(string storeId, int numofItems,string loggedIncustomer)
        {

            return _storedata.AddProductsToStoreAsync(storeId, numofItems, loggedIncustomer).Result;
        }

        public bool RemoveProducts(string storeId, int numofItems,string loggedIncustomer)
        {
            
            return _storedata.RemoveProductsFromStoreAsync(storeId, numofItems, loggedIncustomer).Result;
        }
        public async Task<List<Store>> GetAllCustomerStoresAsync(string customerid)
        {
            return await _storedata.PrintAllCustomerStoresAsync(customerid);
        }
        public int GetNumberofProducts(string storeid)
        {
            return _storedata.GetNumOfStoreproductsAsync(storeid).Result;
        }
        public Task<bool> DeleteStore(string storeID)
        {
            return _storedata.DeleteStoresAsync(storeID);
        }

      public async Task<List<Product>> GetStoresProductAsync(string storeid)
        {
            return await  _storedata.PrintStoreProductsAsync(storeid);
        }

    }
}