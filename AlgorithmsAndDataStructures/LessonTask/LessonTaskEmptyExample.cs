using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.LessonTask
{
    internal class LessonTaskEmptyExample : ILessonTask
    {
        public string TaskName => "EmptyExample";

        public string TaskDescription => "Пример 'пустого' задания, не выполняющего работу";
        public string TaskHelp => "Подсказка по работе с заданием";

        public void RunInteractive()
        {
            Log.Logger.Information($"Выполняется работа в интерактивном режиме. Успешно");
        }

        public void RunTest()
        {
            Log.Logger.Information($"Выполняется тестовый запуск. Успешно");
        }
    }
}
