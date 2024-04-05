

using Microsoft.EntityFrameworkCore;
using WebAPICourse.Data;
using WebAPICourse.Dtos.StockDtos;
using WebAPICourse.Interfaces;
using WebAPICourse.Models;

namespace WebAPICourse.Repository;

public class StockRepository : IStockRepository
{
    private readonly AppDBContext _dbContext;

    public StockRepository(AppDBContext appDBContext)
    {
        _dbContext = appDBContext;
    }

    public async Task<Stock> CreateStockAsync(Stock stockModel)
    {
        await _dbContext.Stocks.AddAsync(stockModel);
        await _dbContext.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> DeleteStockAsync(Stock stockModel)
    {
        _dbContext.Stocks.Remove(stockModel);
        await _dbContext.SaveChangesAsync();
        return stockModel;
    }

    public async Task<List<Stock>> GetAllAsync()
    {
        return await _dbContext.Stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(string Id)
    {
        return await _dbContext.Stocks.FirstOrDefaultAsync(stock => stock.Id == Id);
    }

    public async Task<Stock?> UpdateStockAsync(Stock stockModel, UpdateStockDto updateStockDto)
    {
        if (updateStockDto.Symbol != string.Empty) stockModel.Symbol = updateStockDto.Symbol;
        if (updateStockDto.Purchase != 0.0m) stockModel.Purchase = updateStockDto.Purchase;
        if (updateStockDto.CompanyName != string.Empty) stockModel.CompanyName = updateStockDto.CompanyName;
        if (updateStockDto.Industry != string.Empty) stockModel.Industry = updateStockDto.Industry;
        if (updateStockDto.LastDiv != 0.0m) stockModel.LastDiv = updateStockDto.LastDiv;
        if (updateStockDto.MarketCap != 0.0m) stockModel.MarketCap = updateStockDto.MarketCap;
        await _dbContext.SaveChangesAsync();
        return stockModel;
    }
}
