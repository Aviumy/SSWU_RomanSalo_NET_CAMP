namespace Home_task_1
{
    internal class Cube
    {
        public readonly int size;

        private byte[,,] _pieces;

        public int holes { get; private set; }
        public List<HoleCoords> holeCoords { get; private set; }

        public Cube(byte[,,] pieces)
        {
            size = pieces.GetLength(0);
            _pieces = new byte[size, size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        _pieces[i, j, k] = pieces[i, j, k];
                    }
                }
            }
            holes = 0;
            holeCoords = new List<HoleCoords>();
        }

        public int FindThroughHoles()
        {
            holes = 0;
            holes += FindFrontThroughHoles();
            holes += FindSideThroughHoles();
            holes += FindUpperThroughHoles();
            holes += FindLeftUpperDiagonalThroughHoles();
            holes += FindRightUpperDiagonalThroughHoles();
            return holes;
        }

        private int FindFrontThroughHoles()
        {
            int holes = 0;
            for (int k = 0; k < size; k++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool isHoleThere = true;
                    HoleCoords hole = new HoleCoords { Start = (0, j, k) };
                    for (int i = 0; i < size; i++)
                    {
                        if (_pieces[i, j, k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    if (isHoleThere)
                    {
                        holes++;
                        hole.End = (size - 1, j, k);
                        holeCoords.Add(hole);
                    }
                }
            }
            return holes;
        }

        private int FindSideThroughHoles()
        {
            int holes = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool isHoleThere = true;
                    HoleCoords hole = new HoleCoords { Start = (i, j, 0) };
                    for (int k = 0; k < size; k++)
                    {
                        if (_pieces[i, j, k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    if (isHoleThere)
                    {
                        holes++;
                        hole.End = (i, j, size - 1);
                        holeCoords.Add(hole);
                    }
                }
            }
            return holes;
        }

        private int FindUpperThroughHoles()
        {
            int holes = 0;
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    bool isHoleThere = true;
                    HoleCoords hole = new HoleCoords { Start = (i, 0, k) };
                    for (int j = 0; j < size; j++)
                    {
                        if (_pieces[i, j, k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    if (isHoleThere)
                    {
                        holes++;
                        hole.End = (i, size - 1, k);
                        holeCoords.Add(hole);
                    }
                }
            }
            return holes;
        }

        private int FindLeftUpperDiagonalThroughHoles()
        {
            int holes = 0;
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    bool isHoleThere = true;
                    HoleCoords hole = new HoleCoords { Start = (0, j, k) };
                    for ((int i, int k) pair = (0, k); 
                        pair.k >= 0; 
                        pair.i++, pair.k--)
                    {
                        if (_pieces[pair.i, j, pair.k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    if (isHoleThere)
                    {
                        holes++;
                        hole.End = (k, j, 0);
                        holeCoords.Add(hole);
                    }
                }

                for (int i = 1; i < size; i++)
                {
                    bool isHoleThere = true;
                    HoleCoords hole = new HoleCoords { Start = (i, j, size - 1) };
                    for ((int i, int k) pair = (i, size - 1);
                        pair.i < size;
                        pair.i++, pair.k--)
                    {
                        if (_pieces[pair.i, j, pair.k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    if (isHoleThere)
                    {
                        holes++;
                        hole.End = (size - 1, j, i);
                        holeCoords.Add(hole);
                    }
                }
            }
            return holes;
        }

        private int FindRightUpperDiagonalThroughHoles()
        {
            int holes = 0;
            for (int j = 0; j < size; j++)
            {
                for (int k = size - 1; k >= 0; k--)
                {
                    bool isHoleThere = true;
                    HoleCoords hole = new HoleCoords { Start = (0, j, k) };
                    for ((int i, int k) pair = (0, k);
                        pair.k < size;
                        pair.i++, pair.k++)
                    {
                        if (_pieces[pair.i, j, pair.k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    if (isHoleThere)
                    {
                        holes++;
                        hole.End = (size - 1 - k, j, size - 1);
                        holeCoords.Add(hole);
                    }
                }

                for (int i = 1; i < size; i++)
                {
                    bool isHoleThere = true;
                    HoleCoords hole = new HoleCoords { Start = (i, j, 0) };
                    for ((int i, int k) pair = (i, 0);
                        pair.i < size;
                        pair.i++, pair.k++)
                    {
                        if (_pieces[pair.i, j, pair.k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    if (isHoleThere)
                    {
                        holes++;
                        hole.End = (size - 1, j, size - 1 - i);
                        holeCoords.Add(hole);
                    }
                }
            }
            return holes;
        }
    }
}
