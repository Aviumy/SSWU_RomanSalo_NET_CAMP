using System.Drawing;

namespace Home_task_1
{
    internal class TensorValidator
    {
        public void ValidateCreation(Tensor tensor)
        {
            if (tensor.dimensions < 1)
            {
                throw new ArgumentException("Tensor can not have less than 1 dimension");
            }
            if (tensor.size < 1)
            {
                throw new ArgumentException("Tensor size can not be less than 1");
            }
        }

        public void ValidateIndices(Tensor tensor, int[] indices)
        {
            if (indices.Length != tensor.dimensions - 1)
            {
                throw new ArgumentException("Number of indices should match number of dimensions");
            }
            if (indices.Any(x => x < 0 || x >= tensor.size))
            {
                throw new ArgumentException("Index must not be less than 0 or exceed tensor size");
            }
        }
    }
}
