using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICourse.Models;

public class Stock
{
    public string Id { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Purchase { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = string.Empty;

    public long MarketCap { get; set; }

    public List<Comment> Comments { get; set; } = [];
}
