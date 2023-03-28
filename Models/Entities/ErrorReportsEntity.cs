using System.ComponentModel.DataAnnotations;

namespace ErrorReportApp_Console.Models.Entities;

internal class ErrorReportsEntity
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;
}
