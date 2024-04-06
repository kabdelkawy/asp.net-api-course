

using Microsoft.EntityFrameworkCore;
using WebAPICourse.Data;
using WebAPICourse.Dtos.StockDtos;
using WebAPICourse.Helpers.StockHelpers;
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

    public async Task<List<Stock>> GetStocksAsync(StockQueryObject queryObject)
    {
        var stock = _dbContext.Stocks.Include(comments => comments.Comments).AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryObject.Symbol)) 
            stock.Where(stock => stock.Symbol == queryObject.Symbol);
        if (!string.IsNullOrWhiteSpace(queryObject.CompanyName)) 
            stock.Where(stock => stock.CompanyName == queryObject.CompanyName);

        return await stock.ToListAsync();
    }

    public async Task<Stock?> GetStockAsync(string Id)
    {
        return await _dbContext.Stocks.Include(comments => comments.Comments).FirstOrDefaultAsync(stock => stock.Id == Id);
    }

    public async Task<Stock> CreateStockAsync(Stock stock)
    {
        await _dbContext.Stocks.AddAsync(stock);
        await _dbContext.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateStockAsync(Stock stock, UpdateStockDto updateStockDto)
    {
        if (updateStockDto.Symbol != string.Empty) stock.Symbol = updateStockDto.Symbol;
        if (updateStockDto.Purchase != 0.0m) stock.Purchase = updateStockDto.Purchase;
        if (updateStockDto.CompanyName != string.Empty) stock.CompanyName = updateStockDto.CompanyName;
        if (updateStockDto.Industry != string.Empty) stock.Industry = updateStockDto.Industry;
        if (updateStockDto.LastDiv != 0.0m) stock.LastDiv = updateStockDto.LastDiv;
        if (updateStockDto.MarketCap != 0.0m) stock.MarketCap = updateStockDto.MarketCap;
        await _dbContext.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> DeleteStockAsync(Stock stock)
    {
        _dbContext.Stocks.Remove(stock);
        await _dbContext.SaveChangesAsync();
        return stock;
    }
}
