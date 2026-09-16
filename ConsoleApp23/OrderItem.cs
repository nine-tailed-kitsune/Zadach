namespace ConsoleApp23;

public class OrderItem
{
    public Product Product;
    public int Quantity;

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return Product.Price * Quantity;
    }
}