using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.LessonTask
{
    internal class Lesson1TaskPrimeNumber : ILessonTask
    {
        public string TaskName => "PrimeNumber";

        public string TaskDescription => "Реализация алгоритмов, проверяющих, является ли число простым";

        public string TaskHelp => "Вводите целые числа, которые будут проверяться на принадлежность к множеству простых. Для выхода наберите 'exit' или '0' и нажмите [Enter]";

        public void Run()
        {
            Log.Logger.Information($"Интерактивный режим работы не предусмотрен");
        }

        public void RunTest()
        {
            int a = 37;
            int b = 8;
            Log.Logger.Information($"Положительный сценарий. Значение: {a}, простое - {IsNumberPrime(a)}");
            Log.Logger.Information($"Отрицательный сценарий. Значение: {b}, простое - {IsNumberPrime(b)}");

            long maxValue = 50000;
            Log.Logger.Information($"Эксперимент 1. Анализ производительности алгоритма v1. Перебор чисел до {maxValue}");
            int primeNumbersCount = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 2; i <= maxValue; i++)
            {
                if (IsNumberPrime(i))
                    primeNumbersCount++;
            }
            sw.Stop();
            Log.Logger.Information($"Эксперимент 1. Затрачено времени: {sw.Elapsed}. Найдено простых чисел: {primeNumbersCount}");

            Log.Logger.Information($"Эксперимент 2. Анализ производительности алгоритма v2. Перебор чисел до {maxValue}");
            primeNumbersCount = 0;
            sw.Reset();
            sw.Start();
            for (int i = 2; i <= maxValue; i++)
            {
                if (IsNumberPrimeV2(i))
                    primeNumbersCount++;
            }
            sw.Stop();
            Log.Logger.Information($"Эксперимент 2. Затрачено времени: {sw.Elapsed}. Найдено простых чисел: {primeNumbersCount}");
        }

        /// <summary>
        /// Алгоритм для определения, простое число или нет. 
        /// </summary>
        /// <remarks>Базовая реализация, полный перебор.</remarks>
        /// <param name="number">Проверяемое число.</param>
        bool IsNumberPrime(long number)
        {
            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }

            if (d == 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Алгоритм для определения, простое число или нет. 
        /// </summary>
        /// <remarks>Улучшенная реализация, оптимизированный перебор.</remarks>
        /// <param name="number">Проверяемое число.</param>
        bool IsNumberPrimeV2(long number)
        {
            if (number > 2 && (number % 2) == 0)
                return false;

            int currentValue = 3;

            while (currentValue <= number / 2) // проверяем половину всего числа. Все, что больше, даст результат деления меньше 2 (нецелый).
            {
                if (number % currentValue == 0)
                {
                    return false;
                }
                currentValue = currentValue + 2; // проверять только нечетные значения.
            }
            return true;
        }
    }
}
