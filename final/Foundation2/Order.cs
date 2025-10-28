using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    private string _orderNumber;
    private bool _priorityShipping;

    public Order(Customer customer, bool priorityShipping = false)
    {
        _customer = customer;
        _products = new List<Product>();
        _priorityShipping = priorityShipping;
        _orderNumber = "ORD-" + new Random().Next(1000, 9999);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost;
        if (_priorityShipping)
        {
            shippingCost = _customer.LivesInUSA() ? 15 : 50;
        }
        else
        {
            shippingCost = _customer.LivesInUSA() ? 5 : 35;
        }

        total += shippingCost;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"- {product.GetPackingInfo()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

    public string GetOrderNumber()
    {
        return _orderNumber;
    }

    public bool IsPriorityShipping()
    {
        return _priorityShipping;
    }
}