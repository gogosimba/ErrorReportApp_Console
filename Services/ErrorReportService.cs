
using ErrorReportApp_Console.Contexts;
using ErrorReportApp_Console.Models.Entities;
using ErrorReportApp_Console.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace ErrorReportApp_Console.Services;

internal class ErrorReportService
{
    private readonly DataContext _context = new DataContext();
    public async Task<ErrorReportsEntity> CreateAsync(ReportRegistrationForm form)
    {
        if (await _context.ErrorReports.AnyAsync(x => x.Email == form.Email))
            return null!;

        var errorReportEntity = new ErrorReportsEntity()
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Description = form.Description,
        };

        _context.Add(errorReportEntity);
        await _context.SaveChangesAsync();

        return errorReportEntity;
    }

    public async Task<IEnumerable<ErrorReportsEntity>> GetAllAsync()
    {
        return await _context.ErrorReports.ToListAsync();
    }

    public async Task DeleteAsync(string errorReportEmail)
    {
        var errorReportsEntity = await _context.ErrorReports.FirstOrDefaultAsync(x => x.Email == errorReportEmail);
        if (errorReportsEntity != null) 
        {
            _context.Remove(errorReportsEntity);
            await _context.SaveChangesAsync();
       
        }           
    }
    public async Task DeleteAllAsync()
    {
        using var context = new DataContext();
        var posts = await context.ErrorReports.ToListAsync();
        context.ErrorReports.RemoveRange(posts);
        await context.SaveChangesAsync();
    }
}
