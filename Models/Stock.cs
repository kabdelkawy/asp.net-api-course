
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICourse.Models;

[Table("Stocks")]
public class Stock
{
    public string Id { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public decimal Purchase { get; set; }

    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = string.Empty;

    public long MarketCap { get; set; }

    public List<Comment> Comments { get; set; } = [];

    public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
}
