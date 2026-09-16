namespace ConsoleApp23;

public class Order : ICalculatable
{
    public int Id;
    public string CustomerName;
    public DateTime Date;
    public List<OrderItem> Items;

    public Order(int id, string customerName, DateTime date, List<OrderItem> items)
    {
        Id = id;
        CustomerName = customerName;
        Date = date;
        Items = items;
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (OrderItem item in Items)
        {
            total = total + item.GetTotalPrice();
        }
        return total;
    }
}