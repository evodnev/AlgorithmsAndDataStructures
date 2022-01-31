using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.InputOutput
{
    internal class ConsoleInputOutputHelper : IInputOutputHelper
    {
        private const string InvalidCastTemplate = "Некорректная попытка приведения значения '{0}' к типу '{1}'. Повторите попытку ввода.";
        public T InputSingleValue<T>(string message)
        {
            T value = default(T);
            bool isWaitingForInput = true;
            while (isWaitingForInput)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                try
                {
                    value = (T)Convert.ChangeType(input, typeof(T));
                    isWaitingForInput = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(InvalidCastTemplate, input, typeof(T));
                }
            }
            return value;
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
