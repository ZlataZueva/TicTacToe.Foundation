using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    internal class Board : IBoard
    {
        private readonly IReadOnlyCollection<ICellInternal> _cells;
        private readonly IFigureFactory _figureFactory;


        public int Size { get; }

        public bool IsFilled => _cells.All(cell => !cell.IsEmpty);


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
            _cells = new ReadOnlyCollection<ICellInternal>(Enumerable.Range(0,size)
                .SelectMany(row => 
                    Enumerable.Range(0, size)
                        .Select(column => (ICellInternal)cellFactory.CreateCell(row, column)))
                .ToList());
        }


        public FIllCellResult PlaceFigure(int row, int column, FigureType type)
        {
            try
            {
                var cell = this[row, column];
                if (cell.IsEmpty)
                {
                    cell.Figure = _figureFactory.CreateFigure(type);

                    return FIllCellResult.Success;
                }

                return FIllCellResult.OccupiedCell;
            }
            catch (ArgumentException)
            {
                return FIllCellResult.NonexistentCell;
            }
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}