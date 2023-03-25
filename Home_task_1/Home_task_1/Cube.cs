namespace Home_task_1
{
    internal class Cube
    {
        public readonly int size;
        private byte[,,] _pieces;

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
        }

        public int FindThroughHoles()
        {
            int holes = 0;
            holes += FindFrontThroughHoles();
            holes += FindSideThroughHoles();
            holes += FindUpperThroughHoles();
            return holes;
        }

        private int FindFrontThroughHoles()
        {
            int holes = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool isHoleThere = true;
                    for (int k = 0; k < size; k++)
                    {
                        if (_pieces[k,j,i] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    holes += Convert.ToInt32(isHoleThere);
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
                    for (int k = 0; k < size; k++)
                    {
                        if (_pieces[i, j, k] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    holes += Convert.ToInt32(isHoleThere);
                }
            }
            return holes;
        }

        private int FindUpperThroughHoles()
        {
            int holes = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool isHoleThere = true;
                    for (int k = 0; k < size; k++)
                    {
                        if (_pieces[i, k, j] == 1)
                        {
                            isHoleThere = false;
                            break;
                        }
                    }
                    holes += Convert.ToInt32(isHoleThere);
                }
            }
            return holes;
        }
    }
}
