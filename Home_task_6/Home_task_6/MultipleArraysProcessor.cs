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

        // Варіант 1 - простий: злити всі масиви в один і посортувати його
        //public IEnumerable<int> MergeAndSort()
        //{
        //    List<int> merged = new List<int>();
        //    for (int i = 0; i < _arrays.Length; i++)
        //    {
        //        merged.AddRange(_arrays[i]);
        //    }
        //    merged.Sort();

        //    for (int i = 0; i < merged.Count; i++)
        //    {
        //        yield return merged[i];
        //    }
        //}

        // Варіант 2 - не зливати всі масиви в один, натомість посортувати кожен масив окремо, на місці,
        // і на кожній ітерації знаходити найменший елемент зі всіх масивів.
        // Дозволяє зекономити пам'ять, навідміну від 1 варіанту
        public IEnumerable<int> MergeAndSort()
        {
            // 1) Посортувати кожен масив
            int n = _arrays.Length;
            for (int i = 0; i < n; i++)
            {
                Array.Sort(_arrays[i]);
            }

            // 2) Ініціалізуємо масив індексів, які вказують на індекс найменшого невідвіданого елемента у кожному з масивів.
            //    Оскільки масиви посортовані, на початку кожен цей індекс == 0
            //    Як тільки ми знайдемо і повернемо мін. елемент з конкретного масиву - 
            //    збільшуємо відповідний індекс на 1, щоб на наступних ітераціях не враховувати
            //    вже знайдений і повернений елемент.
            int[] minIndices = new int[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                count += _arrays[i].Length;
            }

            for (int i = 0; i < count; i++)
            {
                // 3) Знаходимо найменший елемент зі всіх масивів, не враховуючи вже знайдених
                int minElem = int.MaxValue;
                int minIndex = int.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    if (minIndices[j] < _arrays[j].Length && _arrays[j][minIndices[j]] <= minElem)
                    {
                        minElem = _arrays[j][minIndices[j]];
                        minIndex = j;
                    }
                }
                // 4) Збільшуємо на 1 відповідний індекс з масиву індексів, і повертаємо елемент
                minIndices[minIndex]++;
                yield return minElem;
            }
        }
    }
}
