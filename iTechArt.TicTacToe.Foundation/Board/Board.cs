using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    public class Board : IBoard
    {
        private readonly IFigureFactory _figureFactory;

        private readonly IReadOnlyCollection<ICellInternal> _cells;


        public int Size { get; }

        public bool IsFilled => _cells.All(cell => !cell.IsEmpty);


        public ICell this[int row, int column]
        {
            get
            {
                if (TryGetCell(row, column, out var cell))
                {
                    return cell;
                }

                throw new ArgumentException("Specified position doesn't exist");
            }
        }


        public Board(int size, ICellFactory cellFactory, IFigureFactory figureFactory)
        {
            _figureFactory = figureFactory;

            Size = size;
            _cells = Enumerable.Range(0, size)
                .SelectMany(row => 
                    Enumerable.Range(0, size)
                        .Select(column => cellFactory.CreateCell(row, column))
                        .Cast<ICellInternal>())
                .ToArray();
        }


        private bool TryGetCell(int row, int column, out ICellInternal cell)
        {
            cell = _cells.FirstOrDefault(c => c.Row == row && c.Column == column);

            return cell != null;
        }


        public FillCellResult PlaceFigure(int row, int column, FigureType type)
        {
            if (TryGetCell(row, column, out var cell))
            {
                if (cell.IsEmpty)
                {
                    cell.Figure = _figureFactory.CreateFigure(type);

                    return FillCellResult.Success;
                }

                return FillCellResult.OccupiedCell;
            }

            return FillCellResult.NonexistentCell;
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