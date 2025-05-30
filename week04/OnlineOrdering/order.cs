// Order.cs
using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public double CalculateTotal()
    {
        double subtotal = 0;
        
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        // Add shipping cost
        double shippingCost = _customer.LivesInUSA() ? 5.0 : 35.0;
        
        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "=== PACKING LABEL ===\n";
        
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()}\n";
            packingLabel += $"Product ID: {product.GetProductId()}\n";
            packingLabel += $"Quantity: {product.GetQuantity()}\n\n";
        }
        
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "=== SHIPPING LABEL ===\n";
        shippingLabel += $"Customer: {_customer.GetName()}\n";
        shippingLabel += $"Address:\n{_customer.GetAddress().GetFullAddress()}\n";
        
        return shippingLabel;
    }
}
