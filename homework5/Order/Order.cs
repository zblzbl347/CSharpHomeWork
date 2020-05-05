using System;
using System.Collections.Generic;

namespace Order
{
    internal class Order : IComparable
    {
        // ReSharper disable once UnusedMember.Global
        public Order(long id)
        {
            Id = id;
        }

        public Order() { }

        public long Id { get; }
        public List<OrderItem> OrderItem { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Order m && m.Id == Id;
        }

        public override int GetHashCode()
        {
            return (int)(Id * 100);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Order order))
            {
                throw new ArgumentException();
            }

            return Id.CompareTo(order.Id);
        }
    }
}
