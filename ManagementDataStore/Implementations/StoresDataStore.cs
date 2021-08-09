using System.IO;
using ManagementModels;
using System.Threading.Tasks;
using System;
using ManagementCommons;
namespace ManagementDataStore
{
    public class StoresDataStore : IStoresDatastore
    {
        static string filepath = "../ManagementDataStore/StoreData.txt";
        public async Task<Store> WriteStoreToFileAsync(Store newstore)
        {
            if (!File.Exists(filepath))
            {
                //Invoking method to create file
                StreamWriter streamWrite = File.CreateText(filepath);
                await streamWrite.DisposeAsync();
            }
            //Checking if user exists before writing
            //var existingCustomer = await ReadCustomerFromFileAsync(customer);
            //if ((existingCustomer.Equals(null)))
            //{
            using (StreamWriter streamWriter = File.AppendText(filepath))
            {
                string StoreDetails = $"{newstore.StoreID}|{newstore.StoreName}|{newstore.TypeOfStore}|{newstore.NumofProducts}";
                streamWriter.WriteLine(StoreDetails);
            }
            //}

            // catch (Exception)
            // {
            //     throw new InvalidDataException("Account Already exists, you cannot register twice!");
            // }

            //Invoking method to get file ready for use

            return newstore;
        }

        public async Task<Store> ReadStoreFromFileAsync(Store store)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("Store Data doesnt exist");
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
                    if (userItem.Contains(store.StoreID))
                    {
                        //Write logic here to print all files
                    }
                }

            }
            return store;
        }

        public void PrintAllStores()
        {
            using (StreamReader streamReader = File.OpenText(filepath))
            {
                //Getting the content in the file and saving it in (fileContent)
                string fileContent = streamReader.ReadToEnd();
                //Triming off empty line space at the end of the content
                fileContent = fileContent.TrimEnd();
                //Splitting contents into single lines (rows)
                string[] storeRow = fileContent.Split(Environment.NewLine);
                //Invoking methods for fomatting display table for printing
                ListDisplayLayout.PrintTableLine();
                ListDisplayLayout.PrintTableRow("StoreID", "StoreName", "StoreType", "No of Products");
                ListDisplayLayout.PrintTableLine();
                // looping through each row items
                foreach (var storeItem in storeRow)
                {
                    //Splitting each row item to get user properties.
                    string[] storeDetails = storeItem.Split('|');
                    //Printing each item to the console.
                    ListDisplayLayout.PrintTableRow(storeDetails[0], storeDetails[1], storeDetails[2], storeDetails[3]);
                    ListDisplayLayout.PrintTableLine();



                }

            }

        }
        public int GetNumOfStoreproducts(string storeId)
        {
            int numOfProducts = 0;
            using (StreamReader streamReader = File.OpenText(filepath))
            {
                //Getting the content in the file and saving it in (fileContent)
                string fileContent = streamReader.ReadToEnd();
                //Triming off empty line space at the end of the content
                fileContent = fileContent.TrimEnd();
                //Splitting contents into single lines (rows)
                string[] storeRow = fileContent.Split(Environment.NewLine);

                foreach (var storeItem in storeRow)
                {
                    string[] storedetails = storeItem.Split('|');
                    numOfProducts = Convert.ToInt32(storedetails[3]);
                }

                return numOfProducts;

            }
        }


    }
}