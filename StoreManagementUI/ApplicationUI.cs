using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using ManagementBL;
using ManagementModels;
namespace StoreManagementUI
{
    public class ApplicationUI
    {
        //private static ConsoleKeyInfo key;
        private static string inputMenu;
        public static string customerID;
        private static string customerFirstName;
        private static string customerLastName;
        private static string customerEmail;
        private static string customerPassword;
        private static string customerConfirmPassword;

        public static void ConsoleDisplay(ICustomerActions actions)
        {

            bool stopApplication = false;
            while (!stopApplication)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("**********************************************************");
                Console.WriteLine("***********************Welcome!!!!!!***********************");
                Console.WriteLine("**********Store Management Console Application*************");
                Console.WriteLine("***** Please follow the prompt to use the Application ****");
                Console.WriteLine("**All name inputs should start with Uppercase; e.g; Wale**");
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Enter: ");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit Application");
                Console.WriteLine("**********************************************************");

                inputMenu = Console.ReadLine();
                bool isValidInput = int.TryParse(inputMenu, out int menuItem);

                //Checking for wrong input menu
                if (!isValidInput || menuItem < 0 || menuItem > 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Invalid Menu Option Entered! Please Enter a valid Option");

                }
                else
                {
                    switch (menuItem)
                    {
                        // Case to add new user
                        case 1:
                            //Requesting User First Name
                            Console.WriteLine("Enter FirstName");
                            customerFirstName = Console.ReadLine();

                            //Making sure user input string is valid
                            while (string.IsNullOrWhiteSpace(customerFirstName) || (!Regex.Match(customerFirstName, "^[A-Z][a-zA-Z]*$").Success))
                            {
                                Console.WriteLine("Please enter a valid FirstName, starting with a Capital Letter");
                                customerFirstName = Console.ReadLine();
                            }
                            //Requesting User Last Name
                            Console.WriteLine("Enter LastName");
                            customerLastName = Console.ReadLine();

                            //Making sure user input string is valid
                            while (string.IsNullOrWhiteSpace(customerLastName) || (!Regex.Match(customerLastName, "^[A-Z][a-zA-Z]*$").Success))
                            {
                                Console.WriteLine("Please enter a valid LastName,starting with a Capital Letter");
                                customerLastName = Console.ReadLine();

                            }
                            //Requesting user email
                            Console.WriteLine("Enter Email address.Format:name@domain.com");
                            customerEmail = Console.ReadLine();

                            // Making sure user email is in the right format
                            while (string.IsNullOrWhiteSpace(customerEmail) || (!Regex.Match(customerEmail, @"^[^@\s]+@[^@\s ]+\.[^@\s]+$").Success))
                            {
                                Console.WriteLine("Please Enter a valid Email address.Format:name@domain.com");
                                customerEmail = Console.ReadLine();
                            }

                            //Requesting User [Password]
                            Console.WriteLine("Enter Password, Format: at least 6 characters, must contain 1 letter, 1 digit and a special character");
                            customerPassword = Console.ReadLine();

                            //Making sure user input string is valid
                            while (string.IsNullOrWhiteSpace(customerPassword) || (!Regex.Match(customerPassword, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@#$%^&!]{6,}$").Success))
                            {
                                Console.WriteLine("Please enter a valid Password");
                                customerPassword = Console.ReadLine();
                            }

                            //Requesting User Confirm Email
                            Console.WriteLine("Confirm Password");
                            customerConfirmPassword = Console.ReadLine();

                            //Making sure user Password matches
                            while (!(customerConfirmPassword == customerPassword))
                            {
                                Console.WriteLine("Password does not match");

                                customerConfirmPassword = Console.ReadLine();

                            }
                            //Invoking method to save user details
                            //user.SaveUserDetails();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;

                            customerID = $"CUS-{DateTime.Now.Year}{DateTime.Now.Day}{DateTime.Now.Minute}{DateTime.Now.Millisecond}";
                            //customerID = Guid.NewGuid().ToString();
                            var newcustomer = actions.RegistrationAsync(customerID, customerFirstName, customerLastName, customerEmail, customerPassword, customerConfirmPassword);
                            Console.WriteLine($"{newcustomer.Result.FirstName} {newcustomer.Result.LastName}: registered Successfully!!!");
                            break;

                        case 2:
                            //Requesting user email
                            Console.WriteLine("Enter Email address.Format:name@domain.com");
                            customerEmail = Console.ReadLine();

                            // Making sure user email is in the right format
                            // *******************Add check for mon registered mails
                            //********************I must read from file
                            while (string.IsNullOrWhiteSpace(customerEmail) || (!Regex.Match(customerEmail, @"^[^@\s]+@[^@\s ]+\.[^@\s]+$").Success))
                            {
                                Console.WriteLine("Please Enter a valid Email address.Format:name@domain.com");
                                customerEmail = Console.ReadLine();
                            }

                            //Requesting User Password
                            // Making sure user email is in the right format
                            // *******************Add check for non registered mails
                            //********************I must read from file
                            Console.WriteLine("Enter Password");
                            customerPassword = Console.ReadLine();

                            //Making sure user Password
                            while (string.IsNullOrWhiteSpace(customerPassword) || (!Regex.Match(customerPassword, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@#$%^&!]{6,}$").Success))
                            {
                                Console.WriteLine("Please enter a valid Password");
                                customerPassword = Console.ReadLine();
                            }

                            var registeredCustomer = actions.LoginAsync(customerEmail, customerPassword).Result;
                            Console.Clear();

                            //Checking if user is registered.
                            //if yes, load the store console
                            if (registeredCustomer.FirstName != null)
                            {
                                try
                                {
                                    Program.ConfigureServices();
                                    IStore storeActions = Program.serviceProvider.GetRequiredService<IStore>();

                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine($"Welcome Customer,{registeredCustomer.FirstName}!!!");
                                    Console.WriteLine($"Your CustomerID is:{registeredCustomer.CustomerID}");
                                    StoreConsoleUI.StoreConsoleDisplay(storeActions, registeredCustomer.CustomerID);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("An error occurred, Store prompt has failed");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Customer not registered");
                            }
                            break;

                        case 0:
                            stopApplication = true;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Thank you! Bye!!!");
                            break;

                        default:
                            Console.WriteLine("Please input a valid menu Option");
                            break;

                    }
                }


            }

            return;


        }
    }
}