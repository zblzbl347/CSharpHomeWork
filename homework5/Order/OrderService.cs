using System;
using System.Collections.Generic;
using System.Linq;

namespace Order
{
    internal class OrderService
    {

        public List<Order> Orders = new List<Order>();

        public void Add(List<OrderItem> orders)
        {
            if ((from order in Orders
                 from orderItem in order.OrderItem
                 from item in orders
                 where item.Equals(orderItem)
                 select orderItem).Any())
            {
                throw new Exception("出现重复id");
            }

            Orders.Add(new Order { OrderItem = orders });
        }

        public void Delete(long id)
        {
            var order = from order1 in Orders where order1.Id == id select order1;
            var enumerable = order.ToList();
            if (!enumerable.Any())
            {
                throw new Exception("没有对应id");
            }
            foreach (var order1 in enumerable) Orders.Remove(order1);
        }

        public void Update(long id, string name, string custom)
        {
            var hasValue = false;
            foreach (var order1 in from order1 in Orders
                                   let order = from orderItem in order1.OrderItem where orderItem.Id == id select orderItem
                                   let orderItems = order.ToList()
                                   where orderItems.Count != 0
                                   select order1)
            {
                hasValue = true;
                foreach (var orderItem in order1.OrderItem.Where(orderItem => orderItem.Id == id))
                {
                    orderItem.Name = name;
                    orderItem.Custom = custom;
                }

                break;
            }

            if (!hasValue)
            {
                throw new Exception("没有该id");
            }
        }

        public string SelectById(long id)
        {
            var order = from order1 in Orders where order1.Id == id select order1;
            var result = order.SelectMany(order1 => order1.OrderItem)
                .Aggregate("", (current, orderItem) => current + (orderItem + "\n"));
            if (result == "")
            {
                throw new Exception("没有该订单id");
            }
            return result;
        }

        public string SelectByName(string name)
        {
            var result = Orders
                .Select(order1 => from orderItem in order1.OrderItem where orderItem.Name == name select orderItem)
                .SelectMany(order => order).Aggregate("", (current, orderItem) => current + (orderItem + "\n"));
            if (result == "")
            {
                throw new Exception("没有该商品");
            }
            return result;
        }

        public string SelectByCustom(string custom)
        {
            var result = Orders
                .Select(order1 => from orderItem in order1.OrderItem where orderItem.Custom == custom select orderItem)
                .SelectMany(order => order).Aggregate("", (current, orderItem) => current + (orderItem + "\n"));
            if (result == "")
            {
                throw new Exception("没有该买家");
            }
            return result;
        }

        public void Sort()
        {
            Orders.Sort();
        }

    }
}
