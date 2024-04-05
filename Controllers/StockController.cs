using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICourse.Data;
using WebAPICourse.Dtos.StockDtos;
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
    public async Task<IActionResult> GetAll()
    {
        var stocks = await _stockRepo.GetAllAsync();

        var stockDto = stocks.Select(stock => stock.ToStockDtoFromModel());
        return Ok(stockDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        Stock? stock = await _stockRepo.GetByIdAsync(id);
        if (stock == null) return NotFound();
        else return Ok(stock.ToStockDtoFromModel());
    }

    [HttpPost]
    public async Task<IActionResult> CreateStock([FromBody] CreateStockDto createStock)
    {
        Stock stockModel = createStock.ToStockModelFromCreateDto();
        await _stockRepo.CreateStockAsync(stockModel);
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDtoFromModel());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateStock([FromRoute] string id, [FromBody] UpdateStockDto updateStockDto)
    {
        Stock? stockModel = await _stockRepo.GetByIdAsync(id);
        if (stockModel == null) return NotFound();
        await _stockRepo.UpdateStockAsync(stockModel, updateStockDto);
        return CreatedAtAction(nameof(GetById), new { id = id }, stockModel.ToStockDtoFromModel());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteStock([FromRoute] string id)
    {
        Stock? stockModel = await _stockRepo.GetByIdAsync(id);
        if (stockModel == null) return NotFound();
        await _stockRepo.DeleteStockAsync(stockModel);
        return NoContent();
    }
}


