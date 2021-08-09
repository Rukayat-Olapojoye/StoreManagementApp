using ManagementModels;
using ManagementDataStore;
namespace ManagementBL
{
    public class Kiosk : IStore
    {

        private readonly IStoresDatastore _storedata;
        public Kiosk(IStoresDatastore storedata)
        {
            _storedata = storedata;
        }
        public Store AddStore(string storeowner, string storeId, string storename, Store.StoreType storetype, int items)
        {
            Store kiosk = new Store
            {
                StoreOwner = storeowner,
                StoreID = storeId,
                StoreName = storename,
                TypeOfStore = storetype,
                NumofProducts = items,

            };
            // Writing store to file
            _storedata.WriteStoreToFileAsync(kiosk);
            return kiosk;
        }

        //Yet to implement this
        public int AddProducts(string storeId, int numofItems)
        {
            //Read from store files 
            return 0;
        }

        //Yet to implement this
        public bool RemoveProducts(string storeId, int items)
        {
            Store kiosk = new Store
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
