using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    internal class Board : IBoard
    {
        private readonly List<ICellInternal> _cells;
        private readonly IFigureFactory _figureFactory;


        public int Size { get; }

        public bool IsFilled
        {
            get
            {
                return _cells.All(cell => !cell.IsEmpty);
            }
        }


        private ICellInternal this[int row, int column]
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


        public Board(int size, ICellFactory cellFactory, IFigureFactory figureFactory)
        {
            Size = size;
            _figureFactory = figureFactory;
            _cells = new List<ICellInternal>();
            for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    _cells.Add((ICellInternal)cellFactory.CreateCell(row, column));
                }
            }
        }


        public void PlaceFigure(int row, int column, FigureType type)
        {
            var cell = this[row, column];
            if (cell.IsEmpty)
            {
                cell.Figure = _figureFactory.CreateFigure(type);
            }
            else
            {
                throw new ArgumentException("Specified position is occupied");
            }
        }
    }
}