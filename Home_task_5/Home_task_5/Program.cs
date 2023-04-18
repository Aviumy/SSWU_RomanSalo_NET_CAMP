using System.Text;

namespace Home_task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task_5_1();
            Task_5_2_Example1();
            Task_5_2_Example2();
        }

        static void Task_5_1()
        {
            List<Tree> trees1 = new List<Tree>()
            {
                new Tree(-1, 3),
                new Tree(-1.25, 2),
                new Tree(2, 1.5),
                new Tree(-3, 1),
                new Tree(-1, 1),
                new Tree(0.5,0.5),
                new Tree(-0.5,-1.5),
                new Tree(2, -2),
                new Tree(3.5, -2.5),
                new Tree(0, -4),
            };
            Garden garden1 = new Garden(trees1);
            List<Tree> trees2 = new List<Tree>()
            {
                new Tree(1.5, 3.5),
                new Tree(1.5, 3),
                new Tree(-1, 2),
                new Tree(4, 2),
                new Tree(1.5, 1.5),
                new Tree(4, 0),
                new Tree(5, -0.5),
                new Tree(1, -1),
            };
            Garden garden2 = new Garden(trees2);

            garden1.BuildFence();
            garden2.BuildFence();

            //Console.WriteLine(garden1 == garden2);
            //Console.WriteLine(garden1 > garden2);
            //Console.WriteLine(garden1 < garden2);
            //Console.WriteLine(garden1 >= garden2);
            //Console.WriteLine(garden1 <= garden2);
        }

        static void Task_5_2_Example1()
        {
            Console.OutputEncoding = Encoding.Unicode;

            ShopSection shop = new ShopSection(
                name: "Універмаг",
                root: null,
                subsections: new List<ShopSection>()
            );

            ShopSection section1 = new ShopSection(
                name: "Продуктовий",
                root: shop,
                subsections: new List<ShopSection>()
            );
            ShopSection section2 = new ShopSection(
                name: "Техніка",
                root: shop,
                subsections: new List<ShopSection>()
            );

            ShopSection goods1_a = new ShopSection(
                name: "Хліб",
                root: section1,
                subsections: null,
                size: (2, 2, 6)
            );
            ShopSection goods1_b = new ShopSection(
                name: "Молоко",
                root: section1,
                subsections: null,
                size: (1, 4, 1)
            );
            ShopSection goods2_a = new ShopSection(
                name: "Телефон",
                root: section2,
                subsections: null,
                size: (5, 1, 8)
            );
            ShopSection goods2_b = new ShopSection(
                name: "Ноутбук",
                root: section2,
                subsections: null,
                size: (15, 4, 12)
            );
            ShopSection goods2_c = new ShopSection(
                name: "Телевізор",
                root: section2,
                subsections: null,
                size: (20, 14, 6)
            );

            section1.Subsections = new List<ShopSection> { goods1_a, goods1_b };
            section2.Subsections = new List<ShopSection> { goods2_a, goods2_b, goods2_c };

            shop.Subsections = new List<ShopSection> { section1, section2 };

            shop.CalculateSize();
            Console.WriteLine(shop);
        }

        static void Task_5_2_Example2()
        {
            Console.OutputEncoding = Encoding.Unicode;

            ShopSection shop = new ShopSection(
                name: "Універмаг",
                root: null,
                subsections: new List<ShopSection>()
            );

            ShopSection section1 = new ShopSection(
                name: "Продуктовий",
                root: shop,
                subsections: new List<ShopSection>()
            );
            ShopSection section2 = new ShopSection(
                name: "Техніка",
                root: shop,
                subsections: new List<ShopSection>()
            );

            ShopSection section2_1 = new ShopSection(
                name: "Побутова техніка",
                root: section2,
                subsections: new List<ShopSection>()
            );
            ShopSection section2_2 = new ShopSection(
                name: "Девайси",
                root: section2,
                subsections: new List<ShopSection>()
            );

            List<ShopSection> goods1 = new List<ShopSection>
            {
                new ShopSection(
                    name: "Хліб",
                    root: section1,
                    subsections: null,
                    size: (2, 2, 6)
                ),
                new ShopSection(
                    name: "Молоко",
                    root: section1,
                    subsections: null,
                    size: (1, 4, 1)
                ),
            };

            List<ShopSection> goods2_1 = new List<ShopSection>
            {
                new ShopSection(
                    name: "Порохотяг",
                    root: section2_1,
                    subsections: null,
                    size: (7, 14, 14)
                ),
                new ShopSection(
                    name: "Електрочайник",
                    root: section2_1,
                    subsections: null,
                    size: (2, 5, 2)
                ),
            };

            List<ShopSection> goods2_2 = new List<ShopSection>
            {
                new ShopSection (
                    name: "Телефон",
                    root: section2_2,
                    subsections: null,
                    size: (5, 1, 8)
                ),
                new ShopSection (
                    name: "Ноутбук",
                    root: section2_2,
                    subsections: null,
                    size: (15, 4, 12)
                ),
                new ShopSection (
                    name: "Телевізор",
                    root: section2_2,
                    subsections: null,
                    size: (20, 14, 6)
                ),
            };

            section2_1.Subsections = goods2_1;
            section2_2.Subsections = goods2_2;

            section1.Subsections = goods1;
            section2.Subsections = new List<ShopSection> { section2_1, section2_2 };

            shop.Subsections = new List<ShopSection> { section1, section2 };

            shop.CalculateSize();
            Console.WriteLine(shop);
        }
    }
}