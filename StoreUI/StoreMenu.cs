using System;
using StoreModels;
using StoreBL;
using Serilog;
namespace StoreUI
{
    public class StoreMenu : IMenu
    {
        private MyStoreBL _storeBL;
        public StoreMenu(MyStoreBL storeBL)
        {
            _storeBL = storeBL;
        }
        
        public void Start()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs.txt")
                .CreateLogger();
            Boolean stay = true;
            do{
                Console.Clear();
                Console.WriteLine("Welcome to Connor's Consignment of Conjuring & Craft!");
                Console.WriteLine("Are you a new or returning customer?");
                Console.WriteLine("[0] New User");
                Console.WriteLine("[1] I'm a returning customer");
                Console.WriteLine("[2] Exit");
                Console.WriteLine("Enter a number:");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        CreateCustomer();
                        SendToLocatinMenu();
                        break;
                    case "1":
                        SearchCustomerName();
                        SendToLocatinMenu();
                        break;
                    case "2":
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input! Not part of the menu options! D:<");
                        break;
                }
                
            }while(stay);
            Log.CloseAndFlush();
        }
        public void SendToLocatinMenu()
        {

            Boolean hasntPicked = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"Welcome {_storeBL.currentCustomer.CustomerName}!");
                Console.WriteLine("Which of our locations do you want to look at?");
                GetLocations();
                Console.WriteLine("Enter ID of store you wish to shop at:");
                string userInput = Console.ReadLine();
                Log.Information("Connecting to Store");
                switch (userInput)
                {
                    case "1":
                        SetLocation(1);
                        break;
                    case "2":
                        SetLocation(2);
                        break;
                    case "3":
                        SetLocation(3);
                        break;
                    default:
                        Console.WriteLine("Invalid input! Not part of the menu options! D:<");
                        hasntPicked = true;
                        break;
                }
            }while(hasntPicked);
            IMenu menu = new LocationMenu(_storeBL);
            menu.Start();
        }
        public void SetLocation(int locationID)
        {
            _storeBL.currentLocation = _storeBL.SetLocation(locationID);
            Console.WriteLine($"You picked: {_storeBL.currentLocation.LocationName}");
            Console.WriteLine("Connecting you now...");
            Console.ReadLine();
        }
        public void CreateCustomer()
        {
            Customer newCustomer = new Customer();
            Console.WriteLine("Please enter your name:");
            newCustomer.CustomerName = Console.ReadLine();
            Console.WriteLine("What's your email?:");
            newCustomer.CustomerEmail = Console.ReadLine();
            _storeBL.CreateCustomer(newCustomer);
            _storeBL.currentCustomer = newCustomer;
            Console.WriteLine("Customer Entered!");
            Console.WriteLine($"Customer info:\n\tName: {newCustomer.CustomerName}\n\tEmail: {newCustomer.CustomerEmail}");
            Console.ReadLine();
            Log.Information("Customer Created!");
        }
        public void CreateLocation()
        {
            Location newLocation = new Location();
            Console.WriteLine("Hello. Enter the Store name please:");
            newLocation.LocationName = Console.ReadLine();
            Console.WriteLine("Address of the Store:");
            newLocation.LocationAddress = Console.ReadLine();
            _storeBL.CreateLocation(newLocation);
            Console.WriteLine("Store Entered!");
            Console.ReadLine();
            Console.WriteLine($"Store info:\n\tName: {newLocation.LocationName}\n\tAddress: {newLocation.LocationAddress}");
        }
        public void GetCustomers()
        {
            foreach(var item in _storeBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public void GetLocations()
        {
            foreach(var item in _storeBL.GetLocations())
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void GetProducts()
        {
            foreach(var item in _storeBL.GetProducts())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        public void SearchCustomerName()
        {
            Console.WriteLine("Enter Customer's Name:");
            Customer foundCustomer = _storeBL.SearchCustomerName(Console.ReadLine());
            if(foundCustomer == null)
            {
                Console.WriteLine("No customer found :(");
                Log.Error("Customer not found in DB!");
            }
            else
            {
                Console.WriteLine(foundCustomer.ToString());
                Log.Information("Customer Found!");
                _storeBL.currentCustomer = foundCustomer;
            }
        }
        public void DeleteCustomer()
        {
            Console.WriteLine("Enter the customer to be deleted:");
            Customer customer2BDeleted = _storeBL.SearchCustomerName(Console.ReadLine());
            if(customer2BDeleted == null)
            {
                Console.WriteLine("We can't find the customer. They may have already been deleted.\nOr you typed their name wrong.");
            }
            else
            {
                _storeBL.DeleteCustomer(customer2BDeleted);
                Console.WriteLine($"Sucess!! {customer2BDeleted.CustomerName} is gone from the Customer Collection");
            }
        }
    }
}