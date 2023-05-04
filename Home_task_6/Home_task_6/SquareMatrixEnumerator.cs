using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_6
{// на кожному елементі має бути не більше 2 умов. Заплутано алгоритмічно у Вас
    internal class SquareMatrixEnumerator : IEnumerator
    {
        private enum Direction
        {
            LeftDown,
            RightUp,
            Down,
            Right
        }

        private int[,] _matrix;
        private int _size;
        private int _row;
        private int _col;
        private Direction _direction;

        public SquareMatrixEnumerator(int[,] matrix)
        {
            _matrix = matrix;
            _size = matrix.GetLength(0);
            Reset();
        }

        public object Current
        {
            get 
            { 
                return _matrix[_row, _col];
            }
        }

        public bool MoveNext()
        {
            if (CheckCoords(_direction))
            {
                MoveAt(_direction);
            }
            else
            {
                MoveAt(SwitchDiagonal(_direction));
                _direction = _direction == Direction.LeftDown ? Direction.RightUp : Direction.LeftDown;
            }
            return _row < _size && _col < _size;
        }

        public void Reset()
        {
            _row = -1;
            _col = 1;
            _direction = Direction.LeftDown;
        }

        private bool CheckCoords(Direction direction)
        {
            if (direction == Direction.LeftDown)
            {
                return _row + 1 < _size && _col - 1 >= 0;
            }
            else if (direction == Direction.RightUp)
            {
                return _row - 1 >= 0 && _col + 1 < _size;
            }
            else if (direction == Direction.Down)
            {
                return _row + 1 < _size;
            }
            else if (direction == Direction.Right)
            {
                return _col + 1 < _size;
            }
            else
            {
                throw new ArgumentException("Invalid direction");
            }
        }

        private void MoveAt(Direction direction)
        {
            if (direction == Direction.LeftDown)
            {
                _row++;
                _col--;
            }
            else if (direction == Direction.RightUp)
            {
                _row--;
                _col++;
            }
            else if (direction == Direction.Down)
            {
                _row++;
            }
            else if (direction == Direction.Right)
            {
                _col++;
            }
            else
            {
                throw new ArgumentException("Invalid direction");
            }
        }

        private Direction SwitchDiagonal(Direction direction)
        {
            if (direction == Direction.LeftDown)
            {
                return CheckCoords(Direction.Down) ? Direction.Down : Direction.Right;
            }
            else if (direction == Direction.RightUp)
            {
                return CheckCoords(Direction.Right) ? Direction.Right : Direction.Down;
            }
            else
            {
                throw new ArgumentException("Invalid direction");
            }
        }
    }
}
