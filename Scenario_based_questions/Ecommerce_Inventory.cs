using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        Category Category { get; }
    }
    public enum Category { Electronics, Clothing, Books, Groceries}
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();
        public IEnumerable<T> GetAll()
        {
            return _products;
        }

        public void AddProduct(T product)
        {
            if(_products.Any(x=> x.Id == product.Id))
            {
                return;
            }
            if (product.Price < 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                return;
            }
            _products.Add(product);
        }
        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            // Should return filtered products
            return _products.Where(x=> predicate(x));
        }
        public decimal CalculateTotalValue()
        {
            // Return sum of all product prices
            return _products.Sum(x => x.Price);
        }
    }

    public class ElectronicProduct : IProduct
    {
       public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; } = "";
    }
    public class DiscountedProduct<T> where T : IProduct
    {
        private T _product;
        private decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));

            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentException("Discount must be between 0 and 100.");

            _discountPercentage = discountPercentage;
        }


        // TODO: Implement calculated price with discount
        public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

        // TODO: Override ToString to show discount details
        public override string ToString()
        {
            return $"{_product.Name} | Original: {_product.Price:C} | " +
                   $"Discount: {_discountPercentage}% | Final: {DiscountedPrice:C}";
        }

    }
    public class InventoryManager
    {
        // TODO: Create method that accepts any IProduct collection
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            // a) Print all product names and prices
            foreach(var item in products)
            {
                Console.WriteLine(item.Name + "  " + item.Price);
            }
            // b) Find the most expensive product
            var mostExpensive = products.OrderByDescending(x => x.Price).First();
            Console.WriteLine(mostExpensive.Name);
            // c) Group products by category
            var groupCategory = products.GroupBy(x => x.Category);
            foreach(var item in groupCategory)
            {
                Console.WriteLine(item.Key + "  " + item.Count());
            }
            // d) Apply 10% discount to Electronics over $500
            var discounted = products.Where(x => x.Category == Category.Electronics && x.Price > 500)
                .Select( x =>new  DiscountedProduct<T>(x, 10));
            foreach (var discount in discounted)
            {
                Console.WriteLine(discount);
            }

        }

        // TODO: Implement bulk price update with delegate
        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
       where T : IProduct
        {
            if (products == null || priceAdjuster == null)
                return;

            foreach (var product in products)
            {
                try
                {
                    decimal newPrice = priceAdjuster(product);

                    if (newPrice <= 0)
                        throw new InvalidOperationException("Adjusted price must be positive.");

                    product.GetType()
                           .GetProperty(nameof(IProduct.Price))?
                           .SetValue(product, newPrice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Price update failed for {product.Name}: {ex.Message}");
                }
            }
        }
    }



    public class Ecommerce_Inventory
    {
        public static void Main()
        {
            var repo = new ProductRepository<ElectronicProduct>();

            var products = new List<ElectronicProduct>
        {
            new() { Id = 1, Name = "Laptop", Price = 1200, Brand = "Dell", WarrantyMonths = 24 },
            new() { Id = 2, Name = "Smartphone", Price = 800, Brand = "Samsung", WarrantyMonths = 12 },
            new() { Id = 3, Name = "Headphones", Price = 150, Brand = "Sony", WarrantyMonths = 12 },
            new() { Id = 4, Name = "Monitor", Price = 400, Brand = "LG", WarrantyMonths = 36 },
            new() { Id = 5, Name = "Tablet", Price = 600, Brand = "Apple", WarrantyMonths = 12 }
        };

            // Add products with validation
            foreach (var p in products)
                repo.AddProduct(p);

            Console.WriteLine($"Total Inventory Value: {repo.CalculateTotalValue():C}");

            // Find by brand
            Console.WriteLine("\n--- Samsung Products ---");
            var samsung = repo.FindProducts(p => p.Brand == "Samsung");
            foreach (var s in samsung)
                Console.WriteLine(s.Name);

            // Inventory processing
            var manager = new InventoryManager();
            manager.ProcessProducts(repo.GetAll());

            // Bulk price update (increase 5%)
            manager.UpdatePrices(products, p => p.Price * 1.05m);

            Console.WriteLine($"\nTotal Value After Update: {repo.CalculateTotalValue():C}");
        }
    }
}
