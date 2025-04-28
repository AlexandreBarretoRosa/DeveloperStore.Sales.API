using System;
using System.Collections.Generic;
using System.Linq;
using DeveloperStore.Sales.API.Domain.Entities;

namespace DeveloperStore.Sales.API.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales = new();

        public void Add(Sale sale)
        {
            _sales.Add(sale);
        }

        public Sale GetById(Guid id)
        {
            return _sales.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Sale sale)
        {
            // Em memória o objeto já é atualizado por referência.
        }
    }
}
