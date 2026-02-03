namespace CSharp.Practice.Restaurant_Management;

class MenuItem
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool IsVegeterian { get; set; }
}

class MenuManager
{
    private List<MenuItem> _menuItems = new List<MenuItem>();

    public void AddItem(string name, string category, double price, bool isVeg)
    {
        if (price < 0)
        {
            return;
        }
        _menuItems.Add(
            new MenuItem
            {
                ItemName = name,
                Category = category,
                Price = price,
                IsVegeterian = isVeg,
            }
        );
    }

    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        return _menuItems.GroupBy(r => r.Category).ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<MenuItem> GetVegeterianItems()
    {
        return _menuItems.Where(r => r.IsVegeterian).ToList();
    }

    public double AveragePriceByCategory(string Category)
    {
        return _menuItems
            .Where(r => r.Category == Category)
            .Select(i => i.Price)
            .DefaultIfEmpty(0)
            .Average();
    }
}

class Program
{
    static void Main(String[] args)
    {
        MenuManager manager = new MenuManager();

        // add items
        manager.AddItem("Spring Rolls", "Appetizer", 120, true);
        manager.AddItem("Chicken Wings", "Appetizer", 180, false);

        manager.AddItem("Paneer Butter Masala", "Main Course", 250, true);
        manager.AddItem("Chicken Biryani", "Main Course", 300, false);

        manager.AddItem("Gulab Jamun", "Dessert", 100, true);
        manager.AddItem("Ice Cream", "Dessert", 90, true);

        // Display menu by course type

        var MenuType = manager.GroupItemsByCategory();
        foreach (var item in MenuType)
        {
            Console.WriteLine("Type: " + item.Key);
            foreach (var items in item.Value)
            {
                Console.WriteLine("Name: " + items.ItemName);
            }
        }
        // display vegeteraian menu
        var vegeteraianMenu = manager.GetVegeterianItems();
        foreach (var items in vegeteraianMenu)
        {
            Console.WriteLine(items.ItemName);
        }

        // Get average price by category
        string category = "Dessert";
        double cost = manager.AveragePriceByCategory(category);
        Console.WriteLine($"Average cost of {category} is {cost}");
    }
}
