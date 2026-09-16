namespace ConsoleApp23;

public class Product
{
    public int Id;
    public string Name;
    public string Category;
    public double Price;
 
    public Product(int id, string name, string category, double price)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
    }
}