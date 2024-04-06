using WebAPICourse.Dtos.StockDtos;
using WebAPICourse.Helpers.StockHelpers;
using WebAPICourse.Models;

namespace WebAPICourse.Interfaces;
public interface IStockRepository
{
    Task<List<Stock>> GetStocksAsync(StockQueryObject queryObject);
    Task<Stock?> GetStockAsync(string id);
    Task<Stock> CreateStockAsync(Stock stock);
    Task<Stock?> UpdateStockAsync(Stock stock, UpdateStockDto updateStockDto);
    Task<Stock?> DeleteStockAsync(Stock stock);
}