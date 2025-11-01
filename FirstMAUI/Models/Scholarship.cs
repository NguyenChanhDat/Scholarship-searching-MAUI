namespace FirstMAUI.Models;

public class Scholarship
{
    public required string Title { get; set; }
    public required string Country { get; set; }
    public required string Level { get; set; }
    public required string Field { get; set; }
    public required string Description { get; set; }
    public required string Deadline { get; set; }
    public bool IsVerified { get; set; }
    public bool IsFullScholarship { get; set; }
    public required string Status { get; set; } // e.g. "verified", "pending"
    public required string PostedBy { get; set; } // optional
}
