namespace Home_task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Chef> chefs = new List<Chef>()
            {
                new PizzaChef("PI | Roman"),
                new DessertChef("DS | Oleh"),
                new DrinkChef("DR | Andrii"),
                new PizzaChef("PI | Alina"),
                new DessertChef("DS | Maryna"),
                new DrinkChef("DR | Vasylyna"),
            };

            List<Dish> dishes = new List<Dish>()
            {
                new Dish("Pizza 4 cheeses", 12, Category.pizza),
                new Dish("Meat pizza", 14, Category.pizza),
                new Dish("Hawaii pizza", 10, Category.pizza),
                new Dish("Tiramisu", 6, Category.dessert),
                new Dish("Cheesecake", 8, Category.dessert),
                new Dish("Banana cake", 7, Category.dessert),
                new Dish("Milkshake", 4, Category.drink),
                new Dish("Juice", 2, Category.drink),
                new Dish("Water", 1, Category.drink),
            };

            List<Order> orders = new List<Order>()
            {
                new Order(new Dictionary<Dish, uint>()
                {
                    { dishes[0], 1 },
                    { dishes[1], 1 },
                    { dishes[3], 2 },
                    { dishes[7], 4 },
                }),
                new Order(new Dictionary<Dish, uint>()
                {
                    { dishes[1], 2 },
                    { dishes[2], 2 },
                    { dishes[5], 4 },
                    { dishes[6], 3 },
                    { dishes[8], 1 },
                }),
            };

            Simulator simulator = new Simulator(chefs, orders);
            for (int i = 1; i <= 30; i++)
            {
                Console.WriteLine(i);
                simulator.Simulate1Second();
            }
        }
    }
}