using System;

namespace DeveloperStore.Sales.API.Domain.Events
{
    public class SaleModifiedEvent
    {
        public Guid SaleId { get; }

        public SaleModifiedEvent(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}