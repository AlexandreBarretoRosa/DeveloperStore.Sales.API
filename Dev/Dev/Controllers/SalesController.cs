using System;
using DeveloperStore.Sales.API.Application.Services;
using DeveloperStore.Sales.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SalesController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public IActionResult CreateSale([FromBody] CreateSaleDto dto)
        {
            var saleId = _saleService.CreateSale(dto);
            return CreatedAtAction(nameof(GetById), new { id = saleId }, saleId);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var sale = _saleService.GetSale(id);
                return Ok(sale);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateSaleDto dto)
        {
            _saleService.UpdateSale(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Cancel(Guid id)
        {
            _saleService.CancelSale(id);
            return NoContent();
        }

        [HttpPost("{saleId}/items/{productId}/cancel")]
        public IActionResult CancelItem(Guid saleId, string productId)
        {
            _saleService.CancelSaleItem(saleId, productId);
            return NoContent();
        }
    }
}
