using ErrorReportApp_Console.Contexts;
using ErrorReportApp_Console.Models.Entities;
using ErrorReportApp_Console.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace ErrorReportApp_Console.Services;

internal class CaseService
{
    public static DataContext _context = new DataContext();

    public static async Task<CaseEntity> SaveAsync(AddCase addCase)
    {
        var _caseEntity = new CaseEntity
        {
            Title = addCase.Title,
            Description = addCase.Description,
            CustomerId = addCase.CustomerId,
            RegDate = addCase.DateAdded,
        };

        _context.Add(_caseEntity);
        await _context.SaveChangesAsync();
        return _caseEntity;
    }

    public static async Task<IEnumerable<Case>> GetAllAsync()
    {
        var _cases = new List<Case>();
        foreach (var _case in await _context.Cases.ToListAsync())
            _cases.Add(new Case
            {
                Id = _case.Id,
                Title = _case.Title,
                Description = _case.Description,
                CustomerId = _case.CustomerId,
                Status = _case.Status,
        
                
                
            });
        return _cases;
    }

    public static async Task<Case> GetAsync(int customerId)
    {
        var _case = await _context.Cases.Include(x => x.Customer).FirstOrDefaultAsync(x => x.CustomerId == customerId);

        if (_case != null)
            return new Case
            {
                Id = _case.Id,
                Description = _case.Description,
                Title = _case.Title,
                CustomerId = _case.CustomerId,
                Status = _case.Status,
            };
        else
            return null!;
    }



    public async Task<CaseEntity> UpdateCaseStatusAsync(int caseId, string newStatus)
    {
        var caseEntity = await _context.Cases.FindAsync(caseId);

        if (caseEntity == null)
        {
            
            return caseEntity;
        }

        caseEntity.Status = newStatus;

        await _context.SaveChangesAsync();

        return caseEntity;
    }
}
