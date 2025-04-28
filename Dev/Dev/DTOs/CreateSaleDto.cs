using System;
using System.Collections.Generic;

namespace DeveloperStore.Sales.API.DTOs
{
    public class CreateSaleDto
    {
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public List<CreateSaleItemDto> Items { get; set; } = new();
    }

    public class CreateSaleItemDto
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}