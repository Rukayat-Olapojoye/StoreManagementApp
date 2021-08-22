using System;
using Microsoft.Extensions.DependencyInjection;
using ManagementBL;
using ManagementDataStore;

namespace StoreManagementUI
{
    class Program
    {
        public static IServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            try
            {
                SeedClass.Seed(new StoreDBContext()).Wait();

               ConfigureServices();

               ICustomerActions actions = serviceProvider.GetRequiredService<ICustomerActions>();
               ApplicationUI.ConsoleDisplay(actions);
            }
            catch (Exception)
            {
                Console.WriteLine("Application could not start");
            }
        }
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<ICustomerActions, CustomerActions>();
            services.AddScoped<ICustomerDatastore, EFCORECustomer>();
            services.AddScoped<IStoresDatastore, EFCoreStore>();
            services.AddScoped<IStore, StoreActions>();
            //services.AddScoped<IStore, Kiosk>();
            serviceProvider = services.BuildServiceProvider();
        }

    }

}

