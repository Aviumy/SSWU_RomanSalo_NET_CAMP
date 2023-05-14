namespace Task_8_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Base obj1 = new Base(5);
            Base obj2 = new Derived(20);
            Derived obj3 = new Derived(20);

            obj1.SomeEvent += () => Console.WriteLine("Base Base");
            obj2.SomeEvent += () => Console.WriteLine("Base Derived");
            obj3.SomeEvent += () => Console.WriteLine("Derived Derived");
            
            obj1.DoSomething();
            obj2.DoSomething();
            obj3.DoSomething();
        }
    }
}