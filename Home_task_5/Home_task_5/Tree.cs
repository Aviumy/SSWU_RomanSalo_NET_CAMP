namespace Home_task_5
{
    internal class Tree
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Tree(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $" X={X}; Y={Y}";
        }
    }
}
