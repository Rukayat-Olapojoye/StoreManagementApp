using System.Threading.Tasks;
using ManagementModels;
using System.Data;
using System.Data.SqlClient;

namespace ManagementDataStore

{
    public class ADOCustomer : ICustomerDatastore
    {
        private const string ConnectionString = @"Data Source= RUQAYYAH-PC\SQLEXPRESS;Initial Catalog=StoreManagementDataStore;Integrated Security=true;";
        public async Task<Customer> ReadCustomerFromDBAsync(Customer customerLogin)
            
        {
           Customer isfoundCustomer = new Customer();

            using (var connection = CreateConnection())
            {

                await connection.OpenAsync();

                string query = "GETREGISTEREDCUSTOMER";

                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add("customerEmail", SqlDbType.VarChar).Value = customerLogin.Email;
                command.Parameters.Add("customerPassword", SqlDbType.VarChar).Value = customerLogin.Password;


                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                   if (reader.Read())
                    {
                        isfoundCustomer = new Customer
                        {
                            CustomerID = reader["CustomerId"].ToString(),
                            FirstName = reader["CustomerFirstName"].ToString(),
                            LastName = reader["CustomerLastName"].ToString()
                        };

                        await reader.CloseAsync();
                       
                    }
                    return isfoundCustomer;

                }
                                
                else {
                    throw new System.Exception("Invalid login details");
                }
            }
           
        }

        public async Task<Customer> WriteCustomerToDBAsync(Customer customer)
        {

            var connection = CreateConnection();
            await connection.OpenAsync();

            string query = "INSERTINTOCUSTOMERS";

            SqlCommand command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("customerID", SqlDbType.VarChar).Value = customer.CustomerID;
            command.Parameters.Add("customerFirstName", SqlDbType.VarChar).Value = customer.FirstName;
            command.Parameters.Add("customerLastName", SqlDbType.VarChar).Value = customer.LastName;
            command.Parameters.Add("customerEmail", SqlDbType.VarChar).Value = customer.Email;
            command.Parameters.Add("customerPassword", SqlDbType.VarChar).Value = customer.Password;
            command.Parameters.Add("confirmPassword", SqlDbType.VarChar).Value = customer.ConfirmPassword;

            var cutomerData = await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
            return customer;
        }
        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }

    }
}