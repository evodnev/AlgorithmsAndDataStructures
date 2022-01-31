using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    internal interface IComputeStrategy
    {
        public abstract void ComputeCount(ref int[,] board, int rowCount, int colCount);
    }

    internal class ComputeStrategySimple : IComputeStrategy
    {
        public void ComputeCount(ref int[,] board, int rowCount, int colCount)
        {
            // Алгоритм 1 - "вправо и вниз"
            for (int i = 1; i < rowCount; i++)
                for (int j = 1; j < rowCount; j++)
                    board[i, j] = board[i - 1, j] + board[i, j - 1];
        }
    }

    internal class ComputeStrategyDiag : IComputeStrategy
    {
        public void ComputeCount(ref int[,] board, int rowCount, int colCount)
        {
            // Алгоритм 1 - "вправо и вниз и по диагонали"
            for (int i = 1; i < rowCount; i++)
                for (int j = 1; j < rowCount; j++)
                    board[i, j] = board[i - 1, j] + board[i, j - 1] + board[i - 1, j - 1];
        }
    }

    internal class KingVariants
    {

        const int RowCount = 8;
        const int ColCount = 8;
        IComputeStrategy _computeStrategy;

        public KingVariants(IComputeStrategy computeStrategy)
        {
            _computeStrategy = computeStrategy;
        }

        public void Run()
        {
            int[,] _board = new int[RowCount, ColCount];

            for (int i = 0; i < RowCount; i++)
                _board[i, 0] = 1;
            for (int j = 0; j < RowCount; j++)
                _board[0, j] = 1;

            _computeStrategy.ComputeCount(ref _board, RowCount, ColCount);

            PrintBoard(ref _board);
        }

        private void PrintBoard(ref int[,] board)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                    Console.Write($"\t{board[i, j]}");
                Console.WriteLine();
            }
        }
    }
}
