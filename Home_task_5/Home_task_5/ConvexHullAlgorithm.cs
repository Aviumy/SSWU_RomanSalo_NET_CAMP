namespace Home_task_5
{
    internal static class ConvexHullAlgorithm
    {
        private const int TURN_LEFT = 1;
        private const int TURN_RIGHT = -1;
        private const int TURN_NONE = 0;

        public static List<Tree> GrahamScan(List<Tree> trees)
        {
            double minY = trees.Min(t => t.Y);
            Tree bottomTree = trees.First(t => t.Y == minY);

            List<Tree> sortedTrees = new List<Tree>(trees);
            sortedTrees.Remove(bottomTree);
            sortedTrees = MergeSort(bottomTree, sortedTrees);

            List<Tree> hull = new List<Tree>
            {
                bottomTree,
                sortedTrees[0],
                sortedTrees[1],
            };
            sortedTrees.RemoveAt(0);
            sortedTrees.RemoveAt(0);

            foreach (Tree tree in sortedTrees)
            {
                DeleteRightPoints(hull, tree);
            }

            return hull;
        }

        private static int Turn(Tree a, Tree b, Tree c)
        {
            return ((b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y)).CompareTo(0);
        }

        private static void DeleteRightPoints(List<Tree> hull, Tree currTree)
        {
            while (hull.Count > 1 && Turn(hull[hull.Count - 2], hull[hull.Count - 1], currTree) != TURN_LEFT)
            {
                hull.RemoveAt(hull.Count - 1);
            }
            if (hull.Count == 0 || hull[hull.Count - 1] != currTree)
            {
                hull.Add(currTree);
            }
        }

        private static double GetAngle(Tree tree1, Tree tree2)
        {
            return Math.Atan2(tree2.Y - tree1.Y, tree2.X - tree1.X) * 180.0 / Math.PI;
        }

        private static List<Tree> MergeSort(Tree bottomTree, List<Tree> list)
        {
            if (list.Count == 1)
            {
                return list;
            }
            List<Tree> arrSortedInt = new List<Tree>();
            int middle = list.Count / 2;
            List<Tree> leftHalf = list.GetRange(0, middle);
            List<Tree> rightHalf = list.GetRange(middle, list.Count - middle);
            leftHalf = MergeSort(bottomTree, leftHalf);
            rightHalf = MergeSort(bottomTree, rightHalf);
            int leftptr = 0;
            int rightptr = 0;
            for (int i = 0; i < leftHalf.Count + rightHalf.Count; i++)
            {
                if (leftptr == leftHalf.Count)
                {
                    arrSortedInt.Add(rightHalf[rightptr]);
                    rightptr++;
                }
                else if (rightptr == rightHalf.Count)
                {
                    arrSortedInt.Add(leftHalf[leftptr]);
                    leftptr++;
                }
                else if (GetAngle(bottomTree, leftHalf[leftptr]) < GetAngle(bottomTree, rightHalf[rightptr]))
                {
                    arrSortedInt.Add(leftHalf[leftptr]);
                    leftptr++;
                }
                else
                {
                    arrSortedInt.Add(rightHalf[rightptr]);
                    rightptr++;
                }
            }
            return arrSortedInt;
        }
    }
}
