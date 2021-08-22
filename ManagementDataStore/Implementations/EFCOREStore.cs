using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementModels;
using Microsoft.EntityFrameworkCore;

namespace ManagementDataStore
{
    public class EFCoreStore: IStoresDatastore
    {
        List<Store> stores = new List<Store>();
        public async Task<Store> WriteStoreToDBAsync(Store newstore)
        {
            using (StoreDBContext context = new StoreDBContext())
            {
                await context.AddAsync(newstore);
                var result = await context.SaveChangesAsync();

                if(result > 0 )
                {
                    return newstore;
                }

                return newstore;
            }
        }
        public async Task<List<Store>> PrintAllCustomerStoresAsync(string customerId)
        {
            using (StoreDBContext context = new StoreDBContext())
            {
                 stores = await context.Stores
                 .Where(store => store.customersId == customerId)
                 .ToListAsync();

                return stores;

              }
       }

        public async Task<int> GetNumOfStoreproductsAsync(string storeId)
        {
            using (StoreDBContext context =  new StoreDBContext())
            {
                Store store =  await context.Stores.FirstOrDefaultAsync(store => store.Id == storeId);

                 var productCount = store.NumofProducts;
                return productCount;
            }
        }

        public async Task<bool> DeleteStoresAsync(string storeID)
        {
            using (StoreDBContext context = new StoreDBContext())
            {
                Store store =await  context.Stores.FirstOrDefaultAsync(store =>store.Id == storeID);
                context.Remove(store);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }
         public async Task<bool> AddProductsToStoreAsync(string storeId, int items, string loggedIncustomer)
        {
            using (StoreDBContext context = new StoreDBContext())
            {
                Store store = context.Stores.FirstOrDefault(store => store.Id == storeId && store.customersId == loggedIncustomer);

                store.NumofProducts = store.NumofProducts + items;
                context.Update(store);
                var result =await context.SaveChangesAsync();
                return result > 0;
            }
        }
     public async Task<bool> RemoveProductsFromStoreAsync(string storeId, int items, string loggedIncustomer)
        {
            using (StoreDBContext context = new StoreDBContext())
            {
                Store store = await context.Stores.FirstOrDefaultAsync(store => store.Id == storeId && store.customersId == loggedIncustomer);
                store.NumofProducts = store.NumofProducts - items;
                context.Update(store);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }

       public async  Task<List<Product>> PrintStoreProductsAsync(string storeId)
        {
            using (StoreDBContext context = new StoreDBContext())
            {
                List<Product> products = await context.Products
                .Where(product => product.storeProductId== storeId)
                .ToListAsync();

                return products;

            }
        }


    }
}
