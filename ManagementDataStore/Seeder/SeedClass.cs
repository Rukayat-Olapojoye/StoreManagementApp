using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementModels;
using Newtonsoft.Json;
using System.IO;

namespace ManagementDataStore
{
   public class SeedClass
    {
        public async static Task Seed(StoreDBContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Customers.Any())
            {
                string data = await File.ReadAllTextAsync(@"C:\Projects\BackEndProjects\Week11\StoreManagementApp\ManagementDataStore\Seeder\Customers.json");
                List<Customer> customer = JsonConvert.DeserializeObject<List<Customer>>(data);

                await context.Customers.AddRangeAsync(customer);

                await context.SaveChangesAsync();
            }

            if (!context.Stores.Any())
            {
                string data = await File.ReadAllTextAsync(@"C:\Projects\BackEndProjects\Week11\StoreManagementApp\ManagementDataStore\Seeder\Stores.json");
                List<Store> stores = JsonConvert.DeserializeObject<List<Store>>(data);

                await context.Stores.AddRangeAsync(stores);

                await context.SaveChangesAsync();

            }

            if (!context.Products.Any())
            {
               string data =  await File.ReadAllTextAsync(@"C:\Projects\BackEndProjects\Week11\StoreManagementApp\ManagementDataStore\Seeder\Products.json");
            
                    List<Product> product = JsonConvert.DeserializeObject<List<Product>>(data);
                await context.Products.AddRangeAsync(product);

                await context.SaveChangesAsync();






                // await context.Products.AddRangeAsync(product);

                await context.SaveChangesAsync();
                
            }
       
        }
    }
}
