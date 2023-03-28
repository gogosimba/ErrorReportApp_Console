using ErrorReportApp_Console.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ErrorReportApp_Console.Contexts;

internal class DataContext : DbContext
{
    #region constructors and overrides
    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jonat\OneDrive\Dokument\Webbdesign\C#\ErrorReportApp_Console\Contexts\ErrorReportAppDatabase.mdf;Integrated Security=True;Connect Timeout=30");
    }
    #endregion
    public DbSet<ErrorReportsEntity> ErrorReports { get; set; }
}
