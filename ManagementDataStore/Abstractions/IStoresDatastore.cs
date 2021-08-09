using ManagementModels;
using System.Threading.Tasks;

namespace ManagementDataStore
{
    public interface IStoresDatastore
    {
        Task<Store> ReadStoreFromFileAsync(Store store);
        Task<Store> WriteStoreToFileAsync(Store newstore);
        void PrintAllStores();
        int GetNumOfStoreproducts(string storeId);

    }
}