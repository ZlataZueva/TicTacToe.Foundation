using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    internal class Board : IBoard
    {
        private readonly List<IFigureSettableCell> _cells;


        public int Size { get; }

        public bool IsFilled
        {
            get
            {
                foreach (var cell in _cells)
                {
                    if (cell.IsEmpty)
                    {

                        return false;
                    }
                }

                return true;
            }
        }


        public Board(int size)
        {
            Size = size;
            _cells = new List<IFigureSettableCell>();
            var cellFactory = new CellFactory();
            for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    _cells.Add((IFigureSettableCell)cellFactory.CreateCell(row, column));
                }
            }
        }


        private IFigureSettableCell this[int row, int column]
        {
            get
            {
                var cell = _cells.FirstOrDefault(c => c.Row == row && c.Column == column);
                if (cell != null)
                {

                    return cell;
                }

                throw new ArgumentException("Specified position doesn't exist");
            }
        }


        public void PlaceFigure(int row, int column, IFigure figure)
        {
            var cell = this[row, column];
            if (cell.IsEmpty)
            {
                cell.Figure = figure;
            }
            else
            {
                throw new ArgumentException("Specified position is occupied");
            }
        }
    }
}