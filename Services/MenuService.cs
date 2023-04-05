using ErrorReportApp_Console.Models.Forms;
using System;

namespace ErrorReportApp_Console.Services
{
    internal class MenuService
    {
       
        public async Task MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  __  __       _         __  __                  ");
            Console.WriteLine(@" |  \/  | __ _(_)_ __   |  \/  | ___ _ __  _   _ ");
            Console.WriteLine(@" | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |");
            Console.WriteLine(@" | |  | | (_| | | | | | | |  | |  __/ | | | |_| |");
            Console.WriteLine(@" |_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|");
            Console.WriteLine(@"                                                 ");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("\n\n[1]Submit a new error report\n");
            Console.WriteLine("[2]View all reports\n");
            Console.WriteLine("[3]Set status of a report\n");
            var menuSelection = Console.ReadLine();
            switch (menuSelection)
            {
                case "1":
                    await CreateErrorReport();
                    break;
                case "2":
                    await ShowAllCasesAsync();
                    break;

            }
        }


        private async Task CreateErrorReport()
        {

            var customer = new Customer();
            var addCase = new AddCase();
            Console.Clear();
            Console.WriteLine("Enter your first name");
            customer.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter your last name");
            customer.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter your email");
            customer.Email = Console.ReadLine() ?? "";
            Console.WriteLine("Enter your phone number");
            customer.PhoneNumber = Console.ReadLine() ?? "";
            Console.WriteLine("Enter your address");
            customer.StreeName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter your zipcode");
            customer.PostalCode = Console.ReadLine() ?? "";
            Console.WriteLine("Enter your city");
            customer.City = Console.ReadLine() ?? "";
            Console.Clear();
            Console.WriteLine("In what category does your error belong?");         
            addCase.Title = Console.ReadLine() ?? "";
            Console.WriteLine("Describe whats wrong in as much detail as possible");
            addCase.Description = Console.ReadLine() ?? "";

            addCase.CustomerId = await CustomerService.SaveAsync(customer);
            await CaseService.SaveAsync(addCase);
            Console.WriteLine("Error submitted!");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
        private async Task ShowAllCasesAsync()
        {
            Console.Clear();

            var cases = await CaseService.GetAllAsync();
            if(cases.Any()) 
            {
                foreach (Case _case in cases)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Casenumber: {_case.Id}");
                    Console.WriteLine($"Casenumber: {_case.Title}");
                    Console.WriteLine($"Casenumber: {_case.Description}");
                    Console.WriteLine($"Casenumber: {_case.Status}");
                    Console.WriteLine($"Casenumber: {_case.CustomerId}");
                    Console.WriteLine("------------------------------");
                }                    
            }
            else
            {
                Console.WriteLine("There is no saved errors");
            }
            Console.ReadKey();
        }


    }
}
