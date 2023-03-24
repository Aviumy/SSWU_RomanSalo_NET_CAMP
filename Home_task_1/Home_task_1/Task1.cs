using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_1
{
    internal class SpiralMatrix
    {
        public enum Direction
        {
            CounterClockwise,
            Clockwise,
        }

        public readonly int rows;
        public readonly int cols;

        private int[,] _matrix;

        public SpiralMatrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            _matrix = new int[rows, cols];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append($"{_matrix[i, j]}\t");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public void Fill(Direction direction = Direction.CounterClockwise)
        {
            List<(int, int)> visited = new List<(int, int)>();
            char pointer = (direction == Direction.CounterClockwise) ? 'v' : '>';
            int value = 1;
            int i = 0;
            int j = 0;
            while (visited.Count < rows * cols)
            {
                _matrix[i, j] = value++;
                visited.Add((i, j));

                if (!IsNextIndexValid(i, j))
                {
                    pointer = RotatePointer(direction);
                }
                FollowThePointer();
            }

            bool IsNextIndexValid(int i, int j)
            {
                switch (pointer)
                {
                    case 'v': i++; break;
                    case '>': j++; break;
                    case '^': i--; break;
                    case '<': j--; break;
                    default: throw new Exception("Invalid direction");
                }

                return i >= 0 && j >= 0 && 
                       i < rows && j < cols &&
                       !visited.Contains((i, j));
            }

            char RotatePointer(Direction direction)
            {
                return pointer switch
                {
                    'v' => direction == Direction.CounterClockwise ? '>' : '<',
                    '>' => direction == Direction.CounterClockwise ? '^' : 'v',
                    '^' => direction == Direction.CounterClockwise ? '<' : '>',
                    '<' => direction == Direction.CounterClockwise ? 'v' : '^',
                    _ => throw new Exception("Invalid direction")
                };
            }

            void FollowThePointer()
            {
                switch (pointer)
                {
                    case 'v': i++; break;
                    case '>': j++; break;
                    case '^': i--; break;
                    case '<': j--; break;
                    default: throw new Exception("Invalid direction");
                }
            }
        }
    }
}
