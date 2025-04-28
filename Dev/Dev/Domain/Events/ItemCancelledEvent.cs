using System;

namespace DeveloperStore.Sales.API.Domain.Events
{
    public class ItemCancelledEvent
    {
        public Guid SaleId { get; }
        public string ProductId { get; }

        public ItemCancelledEvent(Guid saleId, string productId)
        {
            SaleId = saleId;
            ProductId = productId;
        }
    }
}