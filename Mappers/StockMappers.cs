using WebAPICourse.Dtos.StockDtos;
using WebAPICourse.Models;

namespace WebAPICourse.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stock)
    {
        return new StockDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            Purchase = stock.Purchase,
            CompanyName = stock.CompanyName,
            Industry = stock.Industry,
            LastDiv = stock.LastDiv,
            MarketCap = stock.MarketCap,
            Comments = stock.Comments.Select(comment => comment.ToCommentDto()).ToList(),
        };
    }

    public static Stock ToStockModel(this CreateStockDto createStockDto)
    {
        return new Stock
        {
            Id = Guid.NewGuid().ToString(),
            Symbol = createStockDto.Symbol,
            CompanyName = createStockDto.CompanyName,
            Purchase = createStockDto.Purchase,
            LastDiv = createStockDto.LastDiv,
            Industry = createStockDto.Industry,
            MarketCap = createStockDto.MarketCap,
        };
    }
}
