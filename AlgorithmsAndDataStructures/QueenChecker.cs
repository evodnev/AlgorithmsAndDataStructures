//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AlgorithmsAndDataStructures
//{
//    internal class QueenChecker
//    {
//        internal enum CellType
//        {
//            Empty,
//            Queen,
//            Hit
//        }

//        const int RowCount = 8;
//        const int ColCount = 8;


//        private CellType[,] _board = new CellType[RowCount, ColCount];

//        public QueenChecker()
//        {
//            for (int i = 0; i < RowCount; i++)
//            {
//                for (int j = 0; j < ColCount; j++)
//                {
//                    _board[i, j] = CellType.Empty;
//                }
//            }
//        }

//        public void Run()
//        {
//            int queensCount = 0;
//            for (int queen = 0; queen < queensCount)
//                for (int i = 0; i < RowCount; i++)
//                {
//                    for (int j = 0; j < ColCount; j++)
//                    {
//                        if (_board[i, j] != CellType.Queen && _board[i, j] != CellType.Hit)
//                        {
//                            _board[i, j] = CellType.Queen;
//                            if CheckBoard();
//                        }
//                    }
//                }
//        }

//    }
//}
