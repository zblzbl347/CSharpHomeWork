namespace Order
{
    internal class OrderItem
    {

        public long Id { get; }
        public string Name { get; set; }
        public string Custom { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Custom: {Custom}";
        }

        public OrderItem(long id, string name, string custom)
        {
            Id = id;
            Name = name;
            Custom = custom;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem m && m.Id == Id && m.Name == Name && m.Custom == Custom;
        }

        public override int GetHashCode()
        {
            return (int)(Id * 100);
        }
    }
}