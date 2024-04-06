using Microsoft.AspNetCore.Mvc;
using WebAPICourse.Dtos.StockDtos;
using WebAPICourse.Helpers.StockHelpers;
using WebAPICourse.Interfaces;
using WebAPICourse.Mappers;
using WebAPICourse.Models;

namespace WebAPICourse.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly IStockRepository _stockRepo;

    public StockController(IStockRepository stockRepo)
    {
        _stockRepo = stockRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetStocks([FromQuery] StockQueryObject queryObject)
    {
        var stocks = await _stockRepo.GetStocksAsync(queryObject);
        var stocksDto = stocks.Select(stock => stock.ToStockDto());
        return Ok(stocksDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStock([FromRoute] string id)
    {
        Stock? stock = await _stockRepo.GetStockAsync(id);
        if (stock == null) return NotFound();
        else return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateStock([FromBody] CreateStockDto createStock)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Stock stockModel = createStock.ToStockModel();
        await _stockRepo.CreateStockAsync(stockModel);
        return CreatedAtAction(nameof(GetStock), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateStock([FromRoute] string id, [FromBody] UpdateStockDto updateStockDto)
    {
        Stock? stockModel = await _stockRepo.GetStockAsync(id);
        if (stockModel == null) return NotFound();
        await _stockRepo.UpdateStockAsync(stockModel, updateStockDto);
        return CreatedAtAction(nameof(GetStock), new { id }, stockModel.ToStockDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteStock([FromRoute] string id)
    {
        Stock? stockModel = await _stockRepo.GetStockAsync(id);
        if (stockModel == null) return NotFound();
        await _stockRepo.DeleteStockAsync(stockModel);
        return NoContent();
    }
}


