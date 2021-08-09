using System.IO;
using ManagementModels;
using System.Threading.Tasks;
using System;

namespace ManagementDataStore
{
    public class CustomerDatastore : ICustomerDatastore
    {
        static string filepath = "../ManagementDataStore/CustomerAuthentication.txt";
        public async Task<Customer> WriteCustomerToFileAsync(Customer customer)
        {
            if (!File.Exists(filepath))
            {
                //Invoking method to create file
                using StreamWriter streamWrite = File.CreateText(filepath);
                await streamWrite.DisposeAsync();
            }
            //Checking if user exists before writing
            //var existingCustomer = await ReadCustomerFromFileAsync(customer);
            //if ((existingCustomer.Equals(null)))
            //{
            using (StreamWriter streamWriter = File.AppendText(filepath))
            {
                string CustomerDetails = $"{customer.CustomerID}|{customer.FirstName}|{customer.LastName}|{customer.Email}|{customer.Password}|{customer.ConfirmPassword}";
                streamWriter.WriteLine(CustomerDetails);
                await streamWriter.DisposeAsync();
            }

            //}

            // catch (Exception)
            // {
            //     throw new InvalidDataException("Account Already exists, you cannot register twice!");
            // }

            //Invoking method to get file ready for use

            return customer;
        }

        public async Task<Customer> ReadCustomerFromFileAsync(Customer customerlogin)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("Customer storage file doesnt exist");
            }

            using (StreamReader streamReader = File.OpenText(filepath))
            {
                //Getting the content in the file and saving it in (fileContent)
                string fileContent = await streamReader.ReadToEndAsync();
                //Triming off empty line space at the end of the content
                fileContent = fileContent.TrimEnd();
                //Splitting contents into single lines (rows)
                string[] userRow = fileContent.Split(Environment.NewLine);

                foreach (var userItem in userRow)
                {
                    //
                    if ((userItem.Contains(customerlogin.Email)) && (userItem.Contains(customerlogin.Password)))
                    {
                        string[] userDetails = userItem.Split('|');
                        customerlogin.CustomerID = userDetails[0].ToString();
                        customerlogin.FirstName = userDetails[1].ToString();
                        customerlogin.LastName = userDetails[2].ToString();


                    }
                }

            }
            return customerlogin;
        }
    }

}


