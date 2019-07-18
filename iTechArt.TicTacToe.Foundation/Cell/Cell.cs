using System;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Cell
{
    public class Cell : ICellInternal
    {
        public int Row { get; }

        public int Column { get; }

        public bool IsEmpty => Figure == null;

        public IFigure Figure { get; private set; }


        IFigure ICellInternal.Figure
        {
            set
            {
                if (IsEmpty)
                {
                    Figure = value;
                }
                else
                {
                    throw new ArgumentException("Cell is occupied");
                }
            }
        }


        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}