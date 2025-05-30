// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Online Ordering System ===\n");

        // Create first customer (USA)
        Address address1 = new Address("123 Main Street", "Springfield", "Illinois", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        // Create first order
        Order order1 = new Order(customer1);
        
        Product product1 = new Product("Wireless Headphones", "WH-001", 89.99, 2);
        Product product2 = new Product("USB Cable", "USB-003", 12.50, 3);
        Product product3 = new Product("Phone Case", "PC-025", 24.99, 1);
        
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create second customer (International)
        Address address2 = new Address("456 Oak Avenue", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Emily Johnson", address2);

        // Create second order
        Order order2 = new Order(customer2);
        
        Product product4 = new Product("Bluetooth Speaker", "BS-007", 65.00, 1);
        Product product5 = new Product("Screen Protector", "SP-012", 15.99, 2);
        
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Order 1 Information
        Console.WriteLine("ORDER #1");
        Console.WriteLine("--------");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Order Total: ${order1.CalculateTotal():F2}");
        Console.WriteLine();

        // Display Order 2 Information
        Console.WriteLine("ORDER #2");
        Console.WriteLine("--------");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Order Total: ${order2.CalculateTotal():F2}");
        Console.WriteLine();

        // Display shipping cost explanation
        Console.WriteLine("=== SHIPPING COST BREAKDOWN ===");
        Console.WriteLine($"Order #1 Customer lives in USA: {customer1.LivesInUSA()} - Shipping: $5.00");
        Console.WriteLine($"Order #2 Customer lives in USA: {customer2.LivesInUSA()} - Shipping: $35.00");
    }
}