using System;

namespace DeveloperStore.Sales.API.Domain.Entities
{
    public class SaleItem
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount => Quantity * UnitPrice * (1 - Discount);
        public bool Cancelled { get; private set; }

        public SaleItem(string productId, string productName, int quantity, decimal unitPrice, decimal discount)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be > 0.", nameof(quantity));
            if (unitPrice < 0) throw new ArgumentException("UnitPrice cannot be negative.", nameof(unitPrice));
            if (discount < 0 || discount > 1) throw new ArgumentException("Discount must be between 0 and 1.", nameof(discount));

            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            Cancelled = false;
        }

        public void Cancel()
        {
            if (!Cancelled) Cancelled = true;
        }
    }
}