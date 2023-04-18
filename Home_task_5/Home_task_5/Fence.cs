using System.Text;

namespace Home_task_5
{
    internal class Fence
    {
        public List<Tree> HullTrees { get; private set; }
        public double Length { get; private set; }

        public Fence()
        {
            HullTrees = new List<Tree>();
            Length = 0;
        }

        public Fence(List<Tree> hullTrees)
        {
            HullTrees = hullTrees;
            Length = CalculateLength();
        }

        public double CalculateLength()
        {
            double DistanceBetweenTrees(Tree tree1, Tree tree2)
            {
                return Math.Sqrt(Math.Pow(tree1.X - tree2.X, 2) + Math.Pow(tree1.Y - tree2.Y, 2));
            }

            if (HullTrees.Count <= 1)
                return 0;

            double length = 0;
            for (int i = 0; i < HullTrees.Count - 1; i++)
            {
                length += DistanceBetweenTrees(HullTrees[i], HullTrees[i + 1]);
            }
            length += DistanceBetweenTrees(HullTrees[0], HullTrees.Last());
            return length;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder($"Fence with length {Math.Round(Length, 2)} is built on such trees:\n");
            foreach (Tree tree in HullTrees)
            {
                result.AppendLine(tree.ToString());
            }
            return result.ToString();
        }
    }
}
