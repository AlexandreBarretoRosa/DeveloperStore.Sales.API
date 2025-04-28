using System;
using System.Text.Json;

namespace DeveloperStore.Sales.API.Infrastructure.EventPublishers
{
    public class LogEventPublisher : IEventPublisher
    {
        public void Publish<T>(T @event) where T : class
        {
            Console.WriteLine($"Event Published: {typeof(T).Name} → {JsonSerializer.Serialize(@event)}");
        }
    }
}
