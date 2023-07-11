using ErrorReportApp_Console.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace ErrorReportApp_Console.Contexts;

internal class DataContext : DbContext
{
    #region constructors
    public DataContext()
    {
        
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    #endregion
    #region overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jonathans\Documents\ErrorReports.mdf;Integrated Security=True;Connect Timeout=30");
        }

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        base.OnModelCreating(modelBuilder);
    }
    #endregion
    #region entities

    public DbSet<CaseEntity> Cases { get; set; } = null!;
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<AddressEntity> Addresses { get; set; } = null!;



    #endregion

}
