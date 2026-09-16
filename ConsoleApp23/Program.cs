namespace ConsoleApp23;

class Program
{
    static void Main()
    {
        Product laptop = new Product(1, "Ноутбук", "Электроника", 55000);
        Product phone = new Product(2, "Смартфон", "Электроника", 30000);
        Product headphones = new Product(3, "Наушники", "Электроника", 5000);
        Product fridge = new Product(4, "Холодильник", "Бытовая техника", 40000);
        Product vacuum = new Product(5, "Пылесос", "Бытовая техника", 15000);
        Product tshirt = new Product(6, "Футболка", "Одежда", 1500);
        Product jeans = new Product(7, "Джинсы", "Одежда", 3000);
        Product sneakers = new Product(8, "Кроссовки", "Одежда", 6000);

        List<Product> allProducts = new List<Product>();
        allProducts.Add(laptop);
        allProducts.Add(phone);
        allProducts.Add(headphones);
        allProducts.Add(fridge);
        allProducts.Add(vacuum);
        allProducts.Add(tshirt);
        allProducts.Add(jeans);
        allProducts.Add(sneakers);

        List<OrderItem> items1 = new List<OrderItem>();
        items1.Add(new OrderItem(laptop, 1));
        items1.Add(new OrderItem(headphones, 2));

        List<OrderItem> items2 = new List<OrderItem>();
        items2.Add(new OrderItem(phone, 1));
        items2.Add(new OrderItem(tshirt, 3));

        List<OrderItem> items3 = new List<OrderItem>();
        items3.Add(new OrderItem(fridge, 1));

        List<OrderItem> items4 = new List<OrderItem>();
        items4.Add(new OrderItem(vacuum, 1));
        items4.Add(new OrderItem(jeans, 2));
        items4.Add(new OrderItem(sneakers, 1));

        List<OrderItem> items5 = new List<OrderItem>();
        items5.Add(new OrderItem(headphones, 1));
        items5.Add(new OrderItem(tshirt, 1));

        List<OrderItem> items6 = new List<OrderItem>();
        items6.Add(new OrderItem(laptop, 1));
        items6.Add(new OrderItem(phone, 1));

        List<Order> orders = new List<Order>();
        orders.Add(new Order(1, "Иван", new DateTime(2024, 1, 5), items1));
        orders.Add(new Order(2, "Мария", new DateTime(2024, 1, 10), items2));
        orders.Add(new Order(3, "Иван", new DateTime(2024, 1, 15), items3));
        orders.Add(new Order(4, "Пётр", new DateTime(2024, 1, 20), items4));
        orders.Add(new Order(5, "Мария", new DateTime(2024, 1, 25), items5));
        orders.Add(new Order(6, "Ольга", new DateTime(2024, 2, 1), items6));



        Console.WriteLine("Задание 1");
        foreach (Order order in orders)
        {
            Console.WriteLine("Заказ №" + order.Id + " от " + order.CustomerName + ", дата " + order.Date.ToShortDateString());
        }

        Console.WriteLine();



        Console.WriteLine("Задание 2");
        foreach (Order order in orders)
        {
            Console.WriteLine("Заказ №" + order.Id);
            foreach (OrderItem item in order.Items)
            {
                Console.WriteLine(item.Product.Name + " - " + item.Quantity + " шт.");
            }
        }

        Console.WriteLine();



        Console.WriteLine("Задание 3");
        foreach (Order order in orders)
        {
            Console.WriteLine("Заказ №" + order.Id + " стоит " + order.CalculateTotal());
        }

        Console.WriteLine();



        Console.WriteLine("Задание 4");
        Order maxOrder = orders[0];
        for (int i = 1; i < orders.Count; i++)
        {
            if (orders[i].CalculateTotal() > maxOrder.CalculateTotal())
            {
                maxOrder = orders[i];
            }
        }
        Console.WriteLine("Самый дорогой заказ - №" + maxOrder.Id + ", сумма " + maxOrder.CalculateTotal());

        Console.WriteLine();



        Console.WriteLine("Задание 5");
        Order minOrder = orders[0];
        for (int i = 1; i < orders.Count; i++)
        {
            if (orders[i].CalculateTotal() < minOrder.CalculateTotal())
            {
                minOrder = orders[i];
            }
        }
        Console.WriteLine("Самый дешевый заказ - №" + minOrder.Id + ", сумма " + minOrder.CalculateTotal());

        Console.WriteLine();



        Console.WriteLine("Задание 6");
        double revenue = 0;
        foreach (Order order in orders)
        {
            revenue = revenue + order.CalculateTotal();
        }
        Console.WriteLine("Общая выручка: " + revenue);

        Console.WriteLine();



        Console.WriteLine("Задание 7");
        double average = revenue / orders.Count;
        Console.WriteLine("Средняя стоимость заказа: " + average);

        Console.WriteLine();



        Console.WriteLine("Задание 8");
        Console.WriteLine("Введите сумму:");
        double userAmount = Convert.ToDouble(Console.ReadLine());
        foreach (Order order in orders)
        {
            if (order.CalculateTotal() > userAmount)
            {
                Console.WriteLine("Заказ №" + order.Id + " - " + order.CalculateTotal());
            }
        }

        Console.WriteLine();



        Console.WriteLine("Задание 9");
        List<Product> orderedProducts = new List<Product>();
        foreach (Order order in orders)
        {
            foreach (OrderItem item in order.Items)
            {
                if (!orderedProducts.Contains(item.Product))
                {
                    orderedProducts.Add(item.Product);
                }
            }
        }
        foreach (Product product in orderedProducts)
        {
            Console.WriteLine(product.Name);
        }

        Console.WriteLine();



        Console.WriteLine("Задание 10");
        foreach (Product product in allProducts)
        {
            if (!orderedProducts.Contains(product))
            {
                Console.WriteLine(product.Name);
            }
        }

        Console.WriteLine();



        Console.WriteLine("Задание 11");
        List<Product> soldProducts = new List<Product>();
        List<int> soldCounts = new List<int>();
        foreach (Order order in orders)
        {
            foreach (OrderItem item in order.Items)
            {
                int index = soldProducts.IndexOf(item.Product);
                if (index == -1)
                {
                    soldProducts.Add(item.Product);
                    soldCounts.Add(item.Quantity);
                }
                else
                {
                    soldCounts[index] = soldCounts[index] + item.Quantity;
                }
            }
        }
        int bestIndex = 0;
        for (int i = 1; i < soldProducts.Count; i++)
        {
            if (soldCounts[i] > soldCounts[bestIndex])
            {
                bestIndex = i;
            }
        }
        Console.WriteLine("Самый продаваемый товар: " + soldProducts[bestIndex].Name + ", продано " + soldCounts[bestIndex] + " шт.");

        Console.WriteLine();



        Console.WriteLine("Задание 12");
        List<Product> profitProducts = new List<Product>();
        List<double> profitSums = new List<double>();
        foreach (Order order in orders)
        {
            foreach (OrderItem item in order.Items)
            {
                int index = profitProducts.IndexOf(item.Product);
                if (index == -1)
                {
                    profitProducts.Add(item.Product);
                    profitSums.Add(item.GetTotalPrice());
                }
                else
                {
                    profitSums[index] = profitSums[index] + item.GetTotalPrice();
                }
            }
        }
        int topProfitIndex = 0;
        for (int i = 1; i < profitProducts.Count; i++)
        {
            if (profitSums[i] > profitSums[topProfitIndex])
            {
                topProfitIndex = i;
            }
        }
        Console.WriteLine("Больше всего выручки принес: " + profitProducts[topProfitIndex].Name + ", выручка " + profitSums[topProfitIndex]);

        Console.WriteLine();



        Console.WriteLine("Задание 13");
        List<string> customerNames = new List<string>();
        List<int> customerOrderCounts = new List<int>();
        foreach (Order order in orders)
        {
            int index = customerNames.IndexOf(order.CustomerName);
            if (index == -1)
            {
                customerNames.Add(order.CustomerName);
                customerOrderCounts.Add(1);
            }
            else
            {
                customerOrderCounts[index] = customerOrderCounts[index] + 1;
            }
        }
        for (int i = 0; i < customerNames.Count; i++)
        {
            Console.WriteLine(customerNames[i] + " - " + customerOrderCounts[i] + " заказ(ов)");
        }

        Console.WriteLine();



        Console.WriteLine("Задание 14");
        List<string> spendingNames = new List<string>();
        List<double> spendingSums = new List<double>();
        foreach (Order order in orders)
        {
            int index = spendingNames.IndexOf(order.CustomerName);
            if (index == -1)
            {
                spendingNames.Add(order.CustomerName);
                spendingSums.Add(order.CalculateTotal());
            }
            else
            {
                spendingSums[index] = spendingSums[index] + order.CalculateTotal();
            }
        }
        for (int i = 0; i < spendingNames.Count; i++)
        {
            Console.WriteLine(spendingNames[i] + " потратил(а) " + spendingSums[i]);
        }

        Console.WriteLine();



        Console.WriteLine("Задание 15");
        int topSpenderIndex = 0;
        for (int i = 1; i < spendingNames.Count; i++)
        {
            if (spendingSums[i] > spendingSums[topSpenderIndex])
            {
                topSpenderIndex = i;
            }
        }
        Console.WriteLine("Больше всех потратил: " + spendingNames[topSpenderIndex] + " - " + spendingSums[topSpenderIndex]);

        Console.WriteLine();



        Console.WriteLine("Задание 16");
        List<string> categories = new List<string>();
        List<List<string>> categoryProducts = new List<List<string>>();
        foreach (Order order in orders)
        {
            foreach (OrderItem item in order.Items)
            {
                int index = categories.IndexOf(item.Product.Category);
                if (index == -1)
                {
                    categories.Add(item.Product.Category);
                    List<string> newList = new List<string>();
                    newList.Add(item.Product.Name);
                    categoryProducts.Add(newList);
                }
                else
                {
                    if (!categoryProducts[index].Contains(item.Product.Name))
                    {
                        categoryProducts[index].Add(item.Product.Name);
                    }
                }
            }
        }
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine(categories[i] + ":");
            foreach (string name in categoryProducts[i])
            {
                Console.WriteLine("  " + name);
            }
        }



        Console.WriteLine("Задание 17");
        List<string> categoryNames = new List<string>();
        List<int> categoryQuantities = new List<int>();
        foreach (Order order in orders)
        {
            foreach (OrderItem item in order.Items)
            {
                int index = categoryNames.IndexOf(item.Product.Category);
                if (index == -1)
                {
                    categoryNames.Add(item.Product.Category);
                    categoryQuantities.Add(item.Quantity);
                }
                else
                {
                    categoryQuantities[index] = categoryQuantities[index] + item.Quantity;
                }
            }
        }
        for (int i = 0; i < categoryNames.Count; i++)
        {
            Console.WriteLine(categoryNames[i] + " - " + categoryQuantities[i] + " шт.");
        }



        Console.WriteLine("Задание 18");
        List<Product> revenueProducts = new List<Product>();
        List<double> revenueSums = new List<double>();
        foreach (Order order in orders)
        {
            foreach (OrderItem item in order.Items)
            {
                int index = revenueProducts.IndexOf(item.Product);
                if (index == -1)
                {
                    revenueProducts.Add(item.Product);
                    revenueSums.Add(item.GetTotalPrice());
                }
                else
                {
                    revenueSums[index] = revenueSums[index] + item.GetTotalPrice();
                }
            }
        }
        for (int i = 0; i < revenueProducts.Count - 1; i++)
        {
            for (int j = 0; j < revenueProducts.Count - 1 - i; j++)
            {
                if (revenueSums[j] < revenueSums[j + 1])
                {
                    double tempSum = revenueSums[j];
                    revenueSums[j] = revenueSums[j + 1];
                    revenueSums[j + 1] = tempSum;

                    Product tempProduct = revenueProducts[j];
                    revenueProducts[j] = revenueProducts[j + 1];
                    revenueProducts[j + 1] = tempProduct;
                }
            }
        }
        for (int i = 0; i < 3 && i < revenueProducts.Count; i++)
        {
            Console.WriteLine(revenueProducts[i].Name + " - " + revenueSums[i]);
        }
    }
}