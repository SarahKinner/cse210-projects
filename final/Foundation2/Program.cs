using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Address address2 = new Address("45 River Road", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Sarah Kinner", address1);
        Customer customer2 = new Customer("Marie Brown", address2);

        Order order1 = new Order(customer1, true);
        order1.AddProduct(new Product("Laptop", "A123", 899.99, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.50, 2));

        Order order2 = new Order(customer2, false);
        order2.AddProduct(new Product("Headphones", "C789", 120.00, 1));
        order2.AddProduct(new Product("Keyboard", "D321", 75.99, 1));
        order2.AddProduct(new Product("Monitor", "E654", 199.99, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine($"Order Number: {order.GetOrderNumber()}");
            Console.WriteLine($"Priority Shipping: {(order.IsPriorityShipping() ? "Yes" : "No")}");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
            Console.WriteLine(new string('-', 40));
        }
    }
}