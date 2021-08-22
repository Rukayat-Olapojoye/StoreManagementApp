using ManagementModels;
using ManagementDataStore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
namespace ManagementBL
{
    public class Kiosk : IStore
    {

        private readonly IStoresDatastore _storedata;
        public Kiosk(IStoresDatastore storedata)
        {
            _storedata = storedata;
        }
        public async Task<Store> AddStoreAsync(string storeowner, string storeId, string storename, Store.StoreType storetype, int items)
        {
            Store kiosk = new Store
            {
                StoreOwner = storeowner,
                Id = storeId,
                StoreName = storename,
                TypeOfStore = storetype,
                NumofProducts = items,

            };
            // Writing store to db
            var addedStore = await _storedata.WriteStoreToDBAsync(kiosk);
            return addedStore;
        }

        
        public bool AddProducts(string storeId, int numofItems, string loggedIncustomer)
        {
            //Read from store files 
            return _storedata.AddProductsToStoreAsync(storeId, numofItems, loggedIncustomer).Result;
        }

        //Yet to implement this
        public bool RemoveProducts(string storeId, int numofItems, string loggedIncustomer)
        {
            int currentNoofProducts = _storedata.GetNumOfStoreproductsAsync(storeId).Result;
            if (currentNoofProducts <= 100)
            {
                throw new InvalidOperationException("You cannot remove from Kiosk");
            }
            return _storedata.RemoveProductsFromStoreAsync(storeId, numofItems, loggedIncustomer).Result;

        }

       public async Task<List<Store>> GetAllCustomerStoresAsync(string customerid)
        {
            return await _storedata.PrintAllCustomerStoresAsync(customerid);
        }
        //Implemented but not working well.
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
