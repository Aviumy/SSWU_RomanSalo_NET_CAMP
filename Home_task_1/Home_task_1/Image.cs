using System.Text;

namespace Home_task_1
{
    internal class Image
    {
        public readonly int rows;
        public readonly int cols;

        private int[,] _image;

        public Image(int[,] matrix)
        {
            rows = matrix.GetLength(0);
            cols = matrix.GetLength(1);
            _image = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _image[i, j] = matrix[i, j];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append($"{_image[i, j]}\t");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public LineInfo FindLongestHorizontalLine()
        {
            LineInfo longest = new LineInfo(
                color: _image[0, 0],
                start: (0, 0),
                end: (0, 0),
                length: 1
            );

            for (int i = 0; i < rows; i++)
            {
                LineInfo current = new LineInfo(
                    color: _image[i, 0],
                    start: (i, 0),
                    end: (i, 0),
                    length: 1
                );

                for (int j = 1; j < cols; j++)
                {
                    if (_image[i, j] == current.Color)
                    {
                        current.Length++;
                        current.End = (i, j);
                    }
                    else
                    {
                        if (current.Length > longest.Length)
                        {
                            longest = new LineInfo(
                                current.Color,
                                current.Start,
                                current.End,
                                current.Length
                            );
                        }

                        current = new LineInfo(
                            color: _image[i, j],
                            start: (i, j),
                            end: (i, j),
                            length: 1
                        );
                    }
                }

                if (current.Length > longest.Length)
                {
                    longest = new LineInfo(
                        current.Color,
                        current.Start,
                        current.End,
                        current.Length
                    );
                }
            }

            return longest;
        }
    }
}
