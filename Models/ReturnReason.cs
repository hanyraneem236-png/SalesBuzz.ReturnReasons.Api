namespace SalesBuzz.ReturnReasons.Api.Models;

public class ReturnReason
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
}
