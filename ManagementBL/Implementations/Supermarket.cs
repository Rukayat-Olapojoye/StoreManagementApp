using ManagementModels;
using ManagementDataStore;
namespace ManagementBL
{
    public class Supermarket : IStore
    {

        private readonly IStoresDatastore _storedata;
        public Supermarket(IStoresDatastore storedata)
        {
            _storedata = storedata;
        }

        public Store AddStore(string storeowner, string storeId, string storename, Store.StoreType storetype, int items)
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
            _storedata.WriteStoreToFileAsync(supermarket);
            return supermarket;
        }

        //Yet to implement this*****
        public int AddProducts(string storeId, int numofItems)
        {
            //return _storedata.UpdateStoreData(storeId, numofItems);
            return 0;
        }
        //Yet to implement this
        public bool RemoveProducts(string storeId, int items)
        {
            Store supermartet = new Store
            {
                StoreID = storeId
            };
            return true;
        }

        //Implemented but not working well.
        public int GetNumberofProducts(string storeid)
        {
            return _storedata.GetNumOfStoreproducts(storeid);
        }


    }
}