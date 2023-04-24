using System.Text;

namespace Home_task_1
{//Для найкращого результату слід би було зробити клас узагальнення та привести до типу Tensor масиви елементів.
    internal class Tensor
    {
        public readonly int dimensions;
        public readonly int size;

        private int[] _data;
        private TensorValidator _validator;

        public Tensor(int dimensions, int size)
        {
            this.dimensions = dimensions;
            this.size = size;

            _validator = new TensorValidator();
            _validator.ValidateCreation(this);

            _data = new int[(int)Math.Pow(size, dimensions - 1)];
        }

        public void FillRange(int start = 0)
        {
            int index = start;
            for (int i = 0; i < _data.Length; i++, index++)
            {
                _data[i] = index;
            }
        }

        public void FillRandom(int minInclusive, int maxInclusive)
        {
            Random rand = new Random();
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] = rand.Next(minInclusive, maxInclusive + 1);
            }
        }

        public int GetElement(params int[] indices)
        {
            _validator.ValidateIndices(this, indices);

            int index = 0;
            for (int i = 0, dim = dimensions - 2;
                i < indices.Length;
                i++, dim--)
            {
                index += indices[i] * (int)Math.Pow(size, dim);
            }
            return _data[index];
        }

        public void SetElement(int value, params int[] indices)
        {
            _validator.ValidateIndices(this, indices);

            int index = 0;
            for (int i = 0, dim = dimensions - 2;
                i < indices.Length;
                i++, dim--)
            {
                index += indices[i] * (int)Math.Pow(size, dim);
            }
            _data[index] = value;
        }
    }
}
