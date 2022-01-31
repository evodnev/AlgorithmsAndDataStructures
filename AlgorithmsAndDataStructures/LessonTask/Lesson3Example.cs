using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.LessonTask
{
    internal class Lesson3Example : ILessonTask
    {
        public string TaskName => "benchmark";

        public string TaskDescription => "Анализ производительности кода";

        public string TaskHelp => throw new NotImplementedException();

        public void RunInteractive()
        {
            Console.WriteLine("Не предусмотрено");
        }

        public void RunTest()
        {
            //throw new NotImplementedException();
        }
    }
}
