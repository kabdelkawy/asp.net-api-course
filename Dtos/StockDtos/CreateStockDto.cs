using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPICourse.Dtos.StockDtos;

public class CreateStockDto
{
    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [Precision(8,2)]
    public decimal Purchase { get; set; } = 0.0m;

    [Required]
    [Precision(8, 2)]
    public decimal LastDiv { get; set; } = 0.0m;

    [Required]
    public string Industry { get; set; } = string.Empty;

    [Required]
    [Precision(12, 2)]
    public long MarketCap { get; set; } = 0;
}