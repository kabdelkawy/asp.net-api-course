using WebAPICourse.Dtos.StockDtos;
using WebAPICourse.Models;

namespace WebAPICourse.Interfaces;
public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(string Id);
    Task<Stock> CreateStockAsync(Stock stockModel);
    Task<Stock?> UpdateStockAsync(Stock stockModel, UpdateStockDto updateStockDto);
    Task<Stock?> DeleteStockAsync(Stock stock);
}