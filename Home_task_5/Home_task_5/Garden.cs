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

        public static bool operator ==(Garden a, Garden b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Garden a, Garden b)
        {
            return !a.Equals(b);
        }

        public static bool operator <(Garden a, Garden b)
        {
            double diff = a._fence.Length - b._fence.Length;
            return Math.Abs(diff) > Fence.LENGTH_THRESHOLD && diff < 0;
        }

        public static bool operator >(Garden a, Garden b)
        {
            return !(a <= b);
        }

        public static bool operator <=(Garden a, Garden b)
        {
            return a < b || a.Equals(b);
        }

        public static bool operator >=(Garden a, Garden b)
        {
            return !(a < b);
        }

        public override string ToString()
        {
            if (_trees.Count == 0)
                return "This garden has no trees";

            StringBuilder result = new StringBuilder("This garden has trees in:\n");
            foreach (Tree tree in _trees)
            {
                result.AppendLine(tree.ToString());
            }
            result.AppendLine(_fence.ToString());
            return result.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Garden && 
                Math.Abs(this._fence.Length - ((Garden)obj)._fence.Length) < Fence.LENGTH_THRESHOLD;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
