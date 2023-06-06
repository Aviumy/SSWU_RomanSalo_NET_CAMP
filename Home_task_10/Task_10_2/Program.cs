namespace Task_10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_10_2();
        }

        static void Task_10_2()
        {
            List<Product> products = new List<Product>()
            {
                new Food(1, "Apple Juice", 15, new DateOnly(year: 2023, month: 7, day: 6)),
                new Food(2, "Milk", 60, new DateOnly(year: 2023, month: 6, day: 7)),
                new Food(3, "Beetroots", 35, new DateOnly(year: 2023, month: 6, day: 8)),
                new Device(4, "IPhone 17", 16800, (.5f, .9f, .2f)),
                new Device(5, "TV", 25000, (40, 34, 7)),
                new Device(6, "Coffee Machine", 4599, (6, 9, 6)),
                new Clothes(7, "T-Shirt", 400, ClothingSize.M),
                new Clothes(8, "T-Shirt", 400, ClothingSize.L),
                new Clothes(9, "T-Shirt", 400, ClothingSize.XL),
            };

            ProductVisitor visitor = new Product.PriceCountVisitor();
            foreach (var product in products)
            {
                product.CountTotalPrice(visitor);
                Console.WriteLine($"{product.Name}: {product.Price}/{product.TotalPrice}");
            }
        }
    }
}