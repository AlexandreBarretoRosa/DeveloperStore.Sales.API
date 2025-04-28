using System;

namespace DeveloperStore.Sales.API.Domain.Events
{
    public class SaleCancelledEvent
    {
        public Guid SaleId { get; }

        public SaleCancelledEvent(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}