namespace Shop.DomainEvents.Sample.Core.Orders
{
    public class Item
    {
        public Item(string code, string description, int quantity, decimal price)
        {
            Code = code;
            Description = description;
            Quantity = quantity;
            Price = price;
        }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }  
        public decimal Amount => Price * Quantity;
    }
}