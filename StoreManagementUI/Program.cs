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
            services.AddScoped<ICustomerDatastore, CustomerDatastore>();
            services.AddScoped<IStoresDatastore, StoresDataStore>();
            services.AddScoped<IStore, Supermarket>();
            services.AddScoped<IStore, Kiosk>();
            serviceProvider = services.BuildServiceProvider();
        }

    }

}

