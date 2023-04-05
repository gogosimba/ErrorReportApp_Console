namespace ErrorReportApp_Console.Models.Forms;

internal class AddCase
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CustomerId { get; set; }
    public string Status { get; set; } = "Not started";

    public DateTime DateAdded { get; set; } = DateTime.Now;
}
