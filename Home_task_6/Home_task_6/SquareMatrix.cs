using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_6
{
    internal class SquareMatrix : IEnumerable
    {
        private int _size;
        private int[,] _matrix;

        public SquareMatrix(int size)
        {
            _size = size;
            _matrix = new int[size, size];
        }

        public void Fill()
        {
            int value = 1;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _matrix[i, j] = value++;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    result.Append($"{_matrix[i, j]}\t");
                }
                result.AppendLine();
            }
            return result.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return new SquareMatrixEnumerator(_matrix);
        }
    }
}
