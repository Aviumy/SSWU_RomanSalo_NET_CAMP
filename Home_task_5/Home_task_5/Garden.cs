using System.Text;

namespace Home_task_5
{
    internal class Garden
    {
        private List<Tree> _trees;
        private Fence _fence;

        public Garden(List<Tree> trees)
        {
            _trees = trees;
            _fence = new Fence();
        }

        public void BuildFence()
        {
            List<Tree> hullTrees = ConvexHullAlgorithm.GrahamScan(_trees);
            _fence = new Fence(hullTrees);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("This garden has trees in:\n");
            foreach (Tree tree in _trees)
            {
                result.AppendLine(tree.ToString());
            }
            result.AppendLine(_fence.ToString());
            return result.ToString();
        }
    }
}
