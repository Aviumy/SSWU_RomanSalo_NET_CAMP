using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_6
{
    internal class MultipleArraysProcessor
    {
        private int[][] _arrays;

        public MultipleArraysProcessor(int[][] arrays)
        {
            int n = arrays.Length;
            _arrays = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int k = arrays[i].Length;
                _arrays[i] = new int[k];
                for (int j = 0; j < k; j++)
                {
                    _arrays[i][j] = arrays[i][j];
                }
            }
        }

        public IEnumerable<int> MergeAndSort()
        {
            List<int> merged = new List<int>();
            for (int i = 0; i < _arrays.Length; i++)
            {
                merged.AddRange(_arrays[i]);
            }
            merged.Sort();

            for (int i = 0; i < merged.Count; i++)
            {
                yield return merged[i];
            }
        }
    }
}
