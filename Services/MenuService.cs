using ErrorReportApp_Console.Models.Entities;
using ErrorReportApp_Console.Models.Forms;
using System;
using System.ComponentModel.DataAnnotations;

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
            Console.WriteLine("[4]Search for a specific report using customer ID\n");
            Console.WriteLine("[5]Delete a report");
            var menuSelection = Console.ReadLine();
            switch (menuSelection)
            {
                case "1":
                    await CreateErrorReport();
                    break;
                case "2":
                    await ShowAllCasesAsync();
                    break;
                case "3":
                    await UpdateStatus();
                    break;
                case "4":
                    await GetSpecificCase();
                    break;
                case "5":
                    await DeleteCase();
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
            customer.StreetName = Console.ReadLine() ?? "";
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
                    Console.WriteLine($"By: {_case.LastName},{_case.FirstName}");
                    Console.WriteLine($"Casenumber: {_case.Id}");
                    Console.WriteLine($"Category: {_case.Title}");
                    Console.WriteLine($"Description: {_case.Description}");
                    Console.WriteLine($"Status: {_case.Status}");
                    Console.WriteLine($"CustomerID: {_case.CustomerId}");
                    Console.WriteLine("------------------------------");
                }                    
            }
            else
            {
                Console.WriteLine("There are no saved errors");
            }
            Console.ReadKey();
        }

        private async Task UpdateStatus()
        {
            var newStatus = "";          
            var caseService = new CaseService();
            
            Console.Clear();
            Console.WriteLine("Write the assosciated casenumber for your case to update its status");
            var caseId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("[1] Ongoing");
            Console.WriteLine("[2] Completed");
            Console.WriteLine("[3] Custom");
            var selection = Console.ReadLine();
            switch(selection)
            {
                case "1":
                    newStatus = "Ongoing";
                    break;
                case "2":
                    newStatus = "Completed";
                    break;
                case "3":
                    Console.WriteLine("Set a custom status:");
                    newStatus = Console.ReadLine();
                    break;
            }
            var updatedCase = await caseService.UpdateCaseStatusAsync(caseId, newStatus);
            Console.Clear();          
        }
        private async Task GetSpecificCase()
        {
            Console.WriteLine("Enter your customerID");
            var customerID = Convert.ToInt32(Console.ReadLine());
            
            
                Console.Clear();
                var cases = await CaseService.GetAsync(customerID);
                if(cases != null) 
                {
                    Console.WriteLine($"Customer ID: {cases.CustomerId}");
                    Console.WriteLine($"Written by: {cases.LastName}, {cases.FirstName}");
                    Console.WriteLine($"Email: {cases.Email}");
                    Console.WriteLine($"Category: {cases.Title}");
                    Console.WriteLine($"Description: {cases.Description}");
                }
                else
                {
                    Console.WriteLine("No cases found with the provided customer ID, be sure you wrote it correctly");
                }
            
            Console.ReadKey();
        }
        private async Task DeleteCase()
        {
            Console.WriteLine("Enter your customerID");
            var customerID = Convert.ToInt32(Console.ReadLine());
            var _deleteCase = await CaseService.DeleteCaseAsync(customerID);
            if( _deleteCase != null )
            {
                System.Console.WriteLine("Case deleted");
            }
            else
            {
                System.Console.WriteLine("No case matching the CustomerID");
            }
            Console.ReadKey();

        }


    }
}
