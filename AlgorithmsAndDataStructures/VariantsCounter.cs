using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    internal class VariantsCounter
    {
        /*
        P(1) = 1;
        P(N) = P(N – 1) + P(N / 2), при N > 1, если N кратно 2;
        P(N) = P(N – 1), при N > 1, если N не кратно 2.
        */
        public static int GetVariantsCountRecursive(int number)
        {
            Trace.Assert(number > 0);

            if (number == 1)
                return 1;
            if (number % 2 == 0)
            {
                return GetVariantsCountRecursive(number - 1) + GetVariantsCountRecursive(number / 2);
            }
            return GetVariantsCountRecursive(number - 1);
        }

        private static Dictionary<int, int> _variantsCount = new Dictionary<int, int>();

        public static int GetVariantsCountRecursiveMod(int number)
        {
            Trace.Assert(number > 0);
            if (_variantsCount.ContainsKey(number))
                return _variantsCount[number];

            if (number == 1)
            {
                _variantsCount[number] = 1;
                return 1;
            }
            int varCount = 0;
            if (number % 2 == 0)
            {
                varCount = GetVariantsCountRecursiveMod(number - 1) + GetVariantsCountRecursiveMod(number / 2);
            }
            else
                varCount = GetVariantsCountRecursiveMod(number - 1);
            _variantsCount[number] = varCount;
            return varCount;
        }
    }
}
