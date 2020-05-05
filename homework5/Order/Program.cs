using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Order
{
    internal class Program
    {
        private static void Main()
        {
            var orderService = new OrderService();
            var orderItem1 = new OrderItem(1, "apple", "A");
            var orderItem2 = new OrderItem(2, "banana", "B");
            var orderItem3 = new OrderItem(3, "orange", "C");
            var list = new List<OrderItem>
            {
                orderItem1,
                orderItem2,
                orderItem3
            };

            //以下演示Add
            orderService.Add(list);
            foreach (var orderItem in orderService.Orders.SelectMany(orderServiceOrder => orderServiceOrder.OrderItem))
            {
                WriteLine(orderItem);
            }

            //以下演示Add错误
            // OrderItem orderItemError=new OrderItem(1,"error","error");
            // List<OrderItem>listError=new List<OrderItem>();
            // listError.Add(orderItemError);
            // orderService.Add(listError);

            WriteLine();
            //以下演示Update
            orderService.Update(2, "apple", "C");
            foreach (var orderItem in orderService.Orders.SelectMany(orderServiceOrder => orderServiceOrder.OrderItem))
            {
                WriteLine(orderItem);
            }

            //以下演示Update错误
            // orderService.Update(4,"error","error");

            WriteLine();
            //以下演示SelectById
            WriteLine(orderService.SelectById(0));

            //以下演示SelectById错误
            // WriteLine(orderService.SelectById(1));

            WriteLine();
            //以下演示SelectByName（SelectByCustom与它基本一致，故不做演示）
            WriteLine(orderService.SelectByName("apple"));

            //以下演示SelectByName错误
            // WriteLine(orderService.SelectByName("error"));

            WriteLine();
            //以下演示Delete
            orderService.Delete(0);
            foreach (var orderItem in orderService.Orders.SelectMany(orderServiceOrder => orderServiceOrder.OrderItem))
            {
                WriteLine(orderItem);
            }

            //以下演示Delete错误（因为0已被删除，所以无法再次删除）
            // orderService.Delete(0);
        }
    }
}