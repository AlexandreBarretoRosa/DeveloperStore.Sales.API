using System;
using System.Collections.Generic;
using System.Linq;
using DeveloperStore.Sales.API.Domain.ValueObjects;
using DeveloperStore.Sales.API.Domain.Enums;

namespace DeveloperStore.Sales.API.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public string SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public Customer Customer { get; private set; }
        public Branch Branch { get; private set; }
        public List<SaleItem> Items { get; private set; }
        public SaleStatus Status { get; private set; }

        public Sale(string saleNumber, DateTime saleDate, Customer customer, Branch branch)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            Customer = customer;
            Branch = branch;
            Items = new List<SaleItem>();
            Status = SaleStatus.Active;
        }

        public decimal TotalAmount => Items
            .Where(i => !i.Cancelled)
            .Sum(i => i.TotalAmount);

        public void AddItem(string productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");

            var discount = CalculateDiscount(quantity);
            var item = new SaleItem(productId, productName, quantity, unitPrice, discount);
            Items.Add(item);
        }

        private decimal CalculateDiscount(int quantity)
        {
            if (quantity >= 10 && quantity <= 20) return 0.20m;
            if (quantity >= 4) return 0.10m;
            return 0m;
        }

        public void CancelSale()
        {
            if (Status == SaleStatus.Cancelled) return;
            Status = SaleStatus.Cancelled;
        }

        public void CancelItem(string productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId)
                      ?? throw new InvalidOperationException($"Item '{productId}' not found.");
            item.Cancel();
        }
    }
}