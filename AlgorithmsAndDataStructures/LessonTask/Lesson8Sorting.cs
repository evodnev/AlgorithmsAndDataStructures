using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.LessonTask
{
    internal class Lesson8Sorting : ILessonTask
    {
        public string TaskName => "sort";

        public string TaskDescription => "Различные алгоритмы сортировки";

        public string TaskHelp => throw new NotImplementedException();

        public void RunInteractive()
        {
            Console.WriteLine("Не предусмотрено");
        }

        private const int ArrayLength = 40;
        public void RunTest()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int[] unsortedArray = new int[ArrayLength];
            Console.WriteLine("Неотсортированный массив");
            for (int i = 0; i < ArrayLength; i++)
            {
                unsortedArray[i] = rnd.Next(100);
                Console.Write($" {unsortedArray[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("Отсортированный массив");
            QuickSort(unsortedArray, 0, ArrayLength - 1);
            for (int i = 0; i < ArrayLength; i++)
            {
                Console.Write($" {unsortedArray[i]} ");
            }
            Console.WriteLine();

        }

        private void QuickSort(int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];

            do
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }

                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSort(array, i, last);
            if (first < j)
                QuickSort(array, first, j);
        }

    }
}
