namespace DeveloperStore.Sales.API.Domain.ValueObjects
{
    public class Customer
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Customer(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}