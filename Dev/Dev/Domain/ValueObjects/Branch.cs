namespace DeveloperStore.Sales.API.Domain.ValueObjects
{
    public class Branch
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Branch(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}