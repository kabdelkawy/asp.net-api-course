namespace WebAPICourse.Dtos.StockDtos;

public class CreateStockDto
{
    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public decimal Purchase { get; set; } = 0.0m;

    public decimal LastDiv { get; set; } = 0.0m;

    public string Industry { get; set; } = string.Empty;

    public long MarketCap { get; set; } = 0;
}