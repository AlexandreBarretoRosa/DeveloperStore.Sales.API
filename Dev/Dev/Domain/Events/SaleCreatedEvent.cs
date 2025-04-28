using System;

namespace DeveloperStore.Sales.API.Domain.Events
{
    public class SaleCreatedEvent
    {
        public Guid SaleId { get; }
        public string SaleNumber { get; }

        public SaleCreatedEvent(Guid saleId, string saleNumber)
        {
            SaleId = saleId;
            SaleNumber = saleNumber;
        }
    }
}