namespace DeveloperStore.Sales.API.Infrastructure.EventPublishers
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : class;
    }
}