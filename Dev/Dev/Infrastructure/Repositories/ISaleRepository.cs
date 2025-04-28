using System;
using DeveloperStore.Sales.API.Domain.Entities;

namespace DeveloperStore.Sales.API.Infrastructure.Repositories
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        Sale GetById(Guid id);
        void Update(Sale sale);
    }
}
