using System;
using System.Text.RegularExpressions;
using ManagementBL;
using ManagementModels;
using ManagementDataStore;
using ManagementCommons;
namespace StoreManagementUI
{
    public class StoreConsoleUI
    {
        private static string inputMenu;
        private static string StoreID;
        private static string storeName;
        // private static Store.StoreType storetype;
        private static int numberOfProducts;
        private static string InitialValue;



        public static void StoreConsoleDisplay(IStore actions, string loggedIncustomer)
        {
            bool stopStoreConsole = false;
            while (!stopStoreConsole)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("***** Please follow the prompt to create stores ****");
                Console.WriteLine("**All name inputs should start with Uppercase; e.g; Wale**");
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Use Store: ");
                Console.WriteLine("1. Supermarket");
                Console.WriteLine("2. Kiosk");
                Console.WriteLine("3. Add product to stores");
                Console.WriteLine("4. Remove Product from store");
                Console.WriteLine("5. Show number of products in Stores");
                Console.WriteLine("6. Show Stores Details");
                Console.WriteLine("7. Show Products Details for stores");
                Console.WriteLine("8. Delete Store");
                Console.WriteLine("0. Logout");
                Console.WriteLine("**********************************************************");
                inputMenu = Console.ReadLine();
                bool isValidInput = int.TryParse(inputMenu, out int menuItem);

                //Checking for wrong input menu
                if (!isValidInput || menuItem < 0 || menuItem > 7)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Invalid Menu Option Entered! Please Enter a valid Option");

                }

                else
                {
                    switch (menuItem)
                    {
                        case 1:
                            Console.WriteLine("Enter Store Name");
                            storeName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(storeName) || (!Regex.Match(storeName, "^[A-Z][a-zA-Z]*$").Success))
                            {
                                Console.WriteLine("Please enter a valid Store, starting with a Capital Letter");
                                storeName = Console.ReadLine();
                            }

                            Console.WriteLine("Enter Number of Items: ");
                            InitialValue = Console.ReadLine();

                            //Implementing my exception Handler to handle non number inputs
                            while (!int.TryParse(InitialValue, out numberOfProducts))
                            {
                                Console.WriteLine("This is not valid input. Please enter an integer value: ");
                                InitialValue = Console.ReadLine();
                            }
                            StoreID = Guid.NewGuid().ToString();
                            // StoreID = $"STORE-SPMT-{DateTime.Now.Day}{DateTime.Now.Minute}{DateTime.Now.Millisecond}";
                            var supermarket = actions.AddStoreAsync(loggedIncustomer, StoreID, storeName, Store.StoreType.Supermarket, numberOfProducts).Result;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"{supermarket.StoreName} has been added!");
                            break;
                        // Case for kiosk
                        case 2:
                            Console.WriteLine("Enter Store Name");
                            storeName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(storeName) || (!Regex.Match(storeName, "^[A-Z][a-zA-Z]*$").Success))
                            {
                                Console.WriteLine("Please enter a valid Store, starting with a Capital Letter");
                                storeName = Console.ReadLine();
                            }

                            Console.WriteLine("Enter Number of Items: ");
                            InitialValue = Console.ReadLine();

                           
                            while (!int.TryParse(InitialValue, out numberOfProducts))
                            {
                                Console.WriteLine("This is not valid input. Please enter an integer value: ");
                                InitialValue = Console.ReadLine();
                            }
                            //  StoreID = $"STORE-KSK-{DateTime.Now.Day}{DateTime.Now.Minute}{DateTime.Now.Millisecond}"; ;
                            StoreID = Guid.NewGuid().ToString();
                            var kiosk = actions.AddStoreAsync(loggedIncustomer, StoreID, storeName, Store.StoreType.Kiosk, numberOfProducts).Result;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"{kiosk.StoreName} has been added!");
                            break;

                        case 3:
                            //Case to add products to store

                            Console.WriteLine("Enter StoreID : View all stores to get StoreIDs");
                            StoreID = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(StoreID))
                            {
                                Console.WriteLine("Please enter a valid StoreID, starting with capital letter");
                                StoreID = Console.ReadLine();
                            }

                            Console.WriteLine("Enter Number of Items to add: ");
                            InitialValue = Console.ReadLine();

                            while (!int.TryParse(InitialValue, out numberOfProducts))
                            {
                                Console.WriteLine("This is not valid input. Please enter an integer value: ");
                                InitialValue = Console.ReadLine();
                            }

                            if (actions.AddProducts(StoreID, numberOfProducts, loggedIncustomer))
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Products added sucessfully!");
                            }

                            else
                            {
                                throw new InvalidOperationException("Cannot complete operation!");
                            }

                            break;
                        case 4:
                            //Case to remove Items from stores
                            //Not working well, no time to refactor
                            // Console.WriteLine("Which of you stores do want to add product to? Kiosk or Supermarket?");
                            // string storeOption2 = Console.ReadLine();
                            // while (string.IsNullOrWhiteSpace(storeOption2))
                            // {
                            //     Console.WriteLine("Please enter a valid StoreOption");
                            //     storeOption2 = Console.ReadLine();
                            // }
                            Console.WriteLine("Enter StoreID : View all stores to get StoreIDs");
                            StoreID = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(StoreID))
                            {
                                Console.WriteLine("Please enter a valid StoreID, starting with capital letter");
                                StoreID = Console.ReadLine();
                            }

                            Console.WriteLine("Enter Number of Items to remove: ");
                            InitialValue = Console.ReadLine();

                            while (!int.TryParse(InitialValue, out numberOfProducts))
                            {
                                Console.WriteLine("This is not valid input. Please enter an integer value: ");
                                InitialValue = Console.ReadLine();
                            }

                            if (actions.RemoveProducts(StoreID, numberOfProducts, loggedIncustomer))
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Products removed sucessfully!");
                            }

                            break;

                        case 5:
                            Console.WriteLine("Enter StoreID : View all stores to get StoreIDs");
                            StoreID = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(StoreID))
                            {
                                Console.WriteLine("Please enter a valid StoreID, starting with capital letter");
                                StoreID = Console.ReadLine();
                            }
                            //Getting number of products and printing to the console
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"Store: {StoreID} has [{actions.GetNumberofProducts(StoreID)}] products");
                            break;

                        case 6:
                            //print store to console
                            EFCoreStore storedata = new EFCoreStore();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            var customerStores = actions.GetAllCustomerStoresAsync(loggedIncustomer).Result;
                            ListDisplayLayout.PrintTableLine();
                            ListDisplayLayout.PrintTableRow("StoreID", "StoreName", "StoreType", "No of Products");
                            ListDisplayLayout.PrintTableLine();

                            foreach (var data in customerStores)
                            {
                                ListDisplayLayout.PrintTableRow(data.Id, data.StoreName, data.TypeOfStore.ToString(), data.NumofProducts.ToString());
                                ListDisplayLayout.PrintTableLine();
                            }
                            break;


                        case 7:
                            //print store to console
                            EFCoreStore storedata2 = new EFCoreStore();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Enter StoreID : View all stores to get StoreIDs");
                            StoreID = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(StoreID))
                            {
                                Console.WriteLine("Please enter a valid StoreID, starting with capital letter");
                                StoreID = Console.ReadLine();
                            }

                            var StoreProducts = actions.GetStoresProductAsync(StoreID).Result;
                            ListDisplayLayout.PrintTableLine();
                            ListDisplayLayout.PrintTableRow("ProductID", "ProductName", "Quantity");
                            ListDisplayLayout.PrintTableLine();

                            foreach (var data in StoreProducts)
                            {
                                ListDisplayLayout.PrintTableRow(data.Id, data.ProductName, data.Quantity.ToString());
                                ListDisplayLayout.PrintTableLine();
                            }
                            break;

                        case 8:
                            Console.WriteLine("Enter StoreID : View all stores to get StoreIDs");
                            StoreID = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(StoreID))
                            {
                                Console.WriteLine("Please enter a valid StoreID, starting with capital letter");
                                StoreID = Console.ReadLine();
                            }
                           
                            if(actions.DeleteStore(StoreID).Result)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"Store has been deleted.");
                            }
                            //throw new InvalidOperationException("Action Failed to complette!");
                           
                            break;

                        case 0:
                            stopStoreConsole = true;
                            Console.WriteLine("Thank you! Bye!!!");
                            break;

                        default:
                            break;

                    }
                }

            }
        }
    }
}