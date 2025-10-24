using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple St", "Rexburg", "ID", "USA")
        Address address2 = new Address("45 River Road", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Sarah Kinner", address1);
        Customer customer2 = new Customer("Marie Brown", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A123", 899.99, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "C789", 120.00, 1));
        order2.AddProduct(new Product("Keyboard", "D321", 75.99, 1));
        order2.AddProduct(new Product("Monitor", "E654", 199.99, 1));
    }
}