using WebAPICourse.Dtos.StockDtos;
using WebAPICourse.Models;

namespace WebAPICourse.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDtoFromModel(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            Purchase = stockModel.Purchase,
            CompanyName = stockModel.CompanyName,
            Industry = stockModel.Industry,
            LastDiv = stockModel.LastDiv,
            MarketCap = stockModel.MarketCap,
        };
    }

    public static Stock ToStockModelFromCreateDto(this CreateStockDto createStockDto)
    {
        return new Stock
        {
            Id = Guid.NewGuid().ToString(),
            Symbol = createStockDto.Symbol,
            CompanyName = createStockDto.CompanyName,
            Purchase = createStockDto.Purchase,
            LastDiv = createStockDto.LastDiv,
            Industry = createStockDto.Industry,
            MarketCap = createStockDto.MarketCap
        };
    }
}
