using System;
using System.Linq;
using DeveloperStore.Sales.API.Domain.Entities;
using DeveloperStore.Sales.API.Domain.ValueObjects;
using DeveloperStore.Sales.API.Domain.Events;
using DeveloperStore.Sales.API.Infrastructure.Repositories;
using DeveloperStore.Sales.API.Infrastructure.EventPublishers;
using DeveloperStore.Sales.API.DTOs;

namespace DeveloperStore.Sales.API.Application.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _repository;
        private readonly IEventPublisher _eventPublisher;

        public SaleService(ISaleRepository repository, IEventPublisher eventPublisher)
        {
            _repository = repository;
            _eventPublisher = eventPublisher;
        }

        public Guid CreateSale(CreateSaleDto dto)
        {
            var sale = new Sale(
                dto.SaleNumber,
                dto.SaleDate,
                new Customer(dto.CustomerId, dto.CustomerName),
                new Branch(dto.BranchId, dto.BranchName)
            );

            foreach (var item in dto.Items)
            {
                sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
            }

            _repository.Add(sale);
            _eventPublisher.Publish(new SaleCreatedEvent(sale.Id, sale.SaleNumber));

            return sale.Id;
        }

        public SaleDto GetSale(Guid id)
        {
            var sale = _repository.GetById(id);
            if (sale == null) return null;

            return new SaleDto
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                SaleDate = sale.SaleDate,
                CustomerName = sale.Customer.Name,
                BranchName = sale.Branch.Name,
                Status = sale.Status.ToString(),
                TotalAmount = sale.TotalAmount,
                Items = sale.Items.Select(i => new SaleItemDto
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Discount = i.Discount,
                    TotalAmount = i.TotalAmount
                })
                .ToList()
            };
        }

        public void UpdateSale(Guid id, UpdateSaleDto dto)
        {
            var sale = _repository.GetById(id)
                ?? throw new InvalidOperationException("Sale not found.");

            // Remove todos os itens antigos e adiciona os novos
            sale.Items.Clear();
            foreach (var item in dto.Items)
            {
                sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
            }

            _repository.Update(sale);
            _eventPublisher.Publish(new SaleModifiedEvent(sale.Id));
        }

        public void CancelSale(Guid id)
        {
            var sale = _repository.GetById(id)
                ?? throw new InvalidOperationException("Sale not found.");

            sale.CancelSale();
            _repository.Update(sale);
            _eventPublisher.Publish(new SaleCancelledEvent(sale.Id));
        }

        // Se implementou CancelItem, inclua também este método:
        public void CancelSaleItem(Guid saleId, string productId)
        {
            var sale = _repository.GetById(saleId)
                ?? throw new InvalidOperationException("Sale not found.");

            sale.CancelItem(productId);
            _repository.Update(sale);
            _eventPublisher.Publish(new ItemCancelledEvent(sale.Id, productId));
        }
    }
}
