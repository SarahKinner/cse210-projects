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
    }
}