namespace Orc.Collections.Tests
{
    public class Order : IUniqueName
    {
        public string Name { get; set; }

        public Order(string name)
        {
            Name = name;
        }
    }
}