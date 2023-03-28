

using ErrorReportApp_Console.Models.Forms;

namespace ErrorReportApp_Console.Services;

internal class MenuService
{
    private readonly ErrorReportService _errorReportService = new ErrorReportService();
    public async Task MainMenu()
    {
        Console.Clear();
        Console.WriteLine("######MAIN MENU######");
        Console.WriteLine("1. Make a new error report");
        Console.WriteLine("2. Show all error reports");
        Console.WriteLine("3. Show all error reports made by name");
        Console.WriteLine("4. Delete a report");
        Console.WriteLine("5. Delete all reports");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                Console.WriteLine("");
                await CreateMenu();
                break;
            case "2":
                await ShowAllMenu();
                break;
            case "3":
                break;
            case "4":
                await DeleteReportMenu ();
                break;
            case "5":
                await DeleteAll();
                break;

        }

    }

    public async Task CreateMenu()
    {
        var form = new ReportRegistrationForm();
        Console.Clear();
        Console.WriteLine("First Name:"); form.FirstName = Console.ReadLine() ?? "";
        Console.WriteLine("Last Name"); form.LastName = Console.ReadLine() ?? "";
        Console.WriteLine("Email:"); form.Email = Console.ReadLine() ?? "";
        Console.WriteLine("Description:"); form.Description = Console.ReadLine() ?? "";
        var result = await _errorReportService.CreateAsync(form);
        if(result == null)
        {
            Console.WriteLine("There is already a report listed with the email you provided");
        }
        else
        {
            Console.WriteLine($"Report submitted, details emailed to: {result.Email}");
        }

    }
    public async Task ShowAllMenu()
    {
        Console.Clear();
        Console.WriteLine("######CATALOGUE######\n\n");
        foreach(var errorreport in await _errorReportService.GetAllAsync())
        {
           
            Console.WriteLine($"Name:{errorreport.FirstName} {errorreport.LastName} {errorreport.Email}\n{errorreport.Description}\n\n");
        }
        Console.ReadKey();
    }

    public async Task ShowByName()
    {
        Console.Clear();

    }

    public async Task DeleteReportMenu()
    {
         
        Console.Clear();
        Console.WriteLine("Enter the email you used for your report");
        var email = Console.ReadLine();
        if(email != null)
        {
            await _errorReportService.DeleteAsync(email);
            Console.WriteLine("Report deleted");
        }
        else
        {
            Console.WriteLine($"No reports made by {email}");
        }
    }
    public async Task DeleteAll()
    {
        await _errorReportService.DeleteAllAsync();
    }

}
