using ManagementModels;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ManagementDataStore

{
    public class ADOStore : IStoresDatastore
    {
        int currentNoofProducts = 0;
        private const string ConnectionString = @"Data Source= RUQAYYAH-PC\SQLEXPRESS;Initial Catalog=StoreManagementDataStore;Integrated Security=true;";
        public async Task<Store> ReadStoreFromDBAsync(Store store)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();
            return store;
        }
        public async Task<Store> WriteStoreToDBAsync(Store newstore)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "INSERTINTOSTORE";

            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("customerID", SqlDbType.VarChar).Value = newstore.StoreOwner;
            command.Parameters.Add("storeID", SqlDbType.VarChar).Value = newstore.StoreID;
            command.Parameters.Add("storeName", SqlDbType.VarChar).Value = newstore.StoreName;
            command.Parameters.Add("storeType", SqlDbType.VarChar).Value = newstore.TypeOfStore;
            command.Parameters.Add("products", SqlDbType.Int).Value = newstore.NumofProducts;

            var customerData = await command.ExecuteNonQueryAsync();

            return newstore;
        }
        public async Task<List<Store>> PrintAllCustomerStoresAsync(string customerId)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "GETCUSTOMERSTORES";

            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("customerID", SqlDbType.VarChar).Value = customerId;

            var reader = await command.ExecuteReaderAsync();

            List<Store> customerstores = new List<Store>();

            while (reader.Read())
            {
                //The key should be the name of the column in your database
                var store = new Store
                {
                    StoreID = reader["StoreID"].ToString(),
                    StoreName = reader["StoreName"].ToString(),
                    TypeOfStore = (Store.StoreType)Enum.Parse(typeof(Store.StoreType), reader["StoreType"].ToString()),
                    NumofProducts = Convert.ToInt32(reader["Products"])
                };

                customerstores.Add(store);
            }

            return customerstores;


        }
        public async Task<int> GetNumOfStoreproductsAsync(string storeId)
        {
            int nProducts = 0;
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "GETNUMBEROFPRODUCTS";
            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("storeID", SqlDbType.VarChar).Value = storeId;
            var reader = await command.ExecuteReaderAsync();

            if (reader.Read())
            {
                nProducts = Convert.ToInt32(reader["Products"].ToString());
            }

            return nProducts;


        }

        public async Task<bool> DeleteStores(string storeID)
        {
            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "DELETESTORE";
            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("storeID", SqlDbType.VarChar).Value = storeID;
            var result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }

        public async Task<bool> AddProductsToStoreAsync(string storeId, int items, string loggedIncustomer)
        {
            currentNoofProducts = GetNumOfStoreproductsAsync(storeId).Result;
            int newNumberofProducts = currentNoofProducts + items;

            var connection = CreateConnection();
            await connection.OpenAsync();
            string query = "UPDATESTOREPRODUCTS";

            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("storeID", SqlDbType.VarChar).Value = storeId;
            command.Parameters.Add("customerID", SqlDbType.VarChar).Value = loggedIncustomer;
            command.Parameters.Add("products", SqlDbType.Int).Value = newNumberofProducts;

            var result = await command.ExecuteNonQueryAsync();

            return result > 0;

        }
        public async Task<bool> RemoveProductsFromStoreAsync(string storeId, int items, string loggedIncustomer)
        {

            currentNoofProducts = GetNumOfStoreproductsAsync(storeId).Result;
            int newNumberofProducts = currentNoofProducts - items;
            var connection = CreateConnection();
            await connection.OpenAsync();
            string query = "UPDATESTOREPRODUCTS";

            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("storeID", SqlDbType.VarChar).Value = storeId;
            command.Parameters.Add("customerID", SqlDbType.VarChar).Value = loggedIncustomer;
            command.Parameters.Add("products", SqlDbType.Int).Value = newNumberofProducts;

            var result = await command.ExecuteNonQueryAsync();

            return result > 0;

        }


        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }

    }
}