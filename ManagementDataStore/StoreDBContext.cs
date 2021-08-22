using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using ManagementModels;


namespace ManagementDataStore
{
    public class StoreDBContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Store> Stores {get; set;}
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer
                (@"Data Source= RUQAYYAH-PC\SQLEXPRESS;Initial Catalog=StoreManagementEFCOREDatabase;Integrated Security=true;");
        }
    }
}