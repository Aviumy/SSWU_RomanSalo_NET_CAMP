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
            if (HullTrees.Count <= 1)
                return 0;

            double length = 0;
            foreach (Tree tree in HullTrees)
            {
                // TODO
            }
            return length;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Fence is built on such trees:\n");
            foreach (Tree tree in HullTrees)
            {
                result.AppendLine(tree.ToString());
            }
            return result.ToString();
        }
    }
}
