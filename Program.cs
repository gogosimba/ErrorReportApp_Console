
using ErrorReportApp_Console.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        
        MenuService menu = new MenuService();

        while (true)
        { 
            await menu.MainMenu();
        }
    }
}