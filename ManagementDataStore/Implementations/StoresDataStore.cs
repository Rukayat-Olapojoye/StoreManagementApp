using System.IO;
using ManagementModels;
using System.Threading.Tasks;
using System;
using ManagementCommons;
using System.Collections.Generic;
namespace ManagementDataStore
{
    public class StoresDataStore
    {

        int numOfProducts;

        static string filepath = "../ManagementDataStore/StoreData.txt";
        public async Task<Store> WriteStoreToDBAsync(Store newstore)
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
                string StoreDetails = $"{newstore.customersId}|{newstore.Id}|{newstore.StoreName}|{newstore.TypeOfStore}|{newstore.NumofProducts}";
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

        public async Task<Store> ReadStoreFromDBAsync(Store store)
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
                    if (userItem.Contains(store.Id))
                    {
                        //Write logic here to print all files
                    }
                }

            }
            return store;
        }

        public async Task<List<Store>> PrintAllCustomerStoresAsync(string customerID)
        {
            using (StreamReader streamReader = File.OpenText(filepath))
            {
                string fileContent = await streamReader.ReadToEndAsync();
                fileContent = fileContent.TrimEnd();
                string[] storeRow = fileContent.Split(Environment.NewLine);
                List<Store> storeList = new List<Store>();
                foreach (string storeItem in storeRow)
                {
                    var storedetails = storeItem.Split('|');
                    if (storedetails[0] == customerID)
                    {
                        var foundstore = new Store
                        {
                            customersId = storedetails[0],
                            Id = storedetails[1],
                            StoreName = storedetails[2],
                            TypeOfStore = (Store.StoreType)Enum.Parse(typeof(Store.StoreType), storedetails[3]),
                            NumofProducts = Int32.Parse(storedetails[4])
                        };

                        storeList.Add(foundstore);
                    }

                }
                return storeList;
            }

        }
        public int GetNumOfStoreproductsAsync(string storeId)
        {

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