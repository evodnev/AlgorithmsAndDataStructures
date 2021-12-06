using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.LessonTask
{
    internal interface ILessonTask
    {
        string TaskName { get; }

        string TaskDescription { get; }

        string TaskHelp { get; }

        void RunTest();

        void Run();
    }
}
