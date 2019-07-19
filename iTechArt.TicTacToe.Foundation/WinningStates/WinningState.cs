using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private readonly IBoard _board;
        private readonly Func<ICell, bool> _filter;
        
        public IEnumerable<ICell> Cells { get; private set; }
        
        public bool IsPresent
        {
            get
            {
                if (Cells != null)
                {
                    return true;
                }
                if (CellsFilledWithFiguresOfOneType(_board.Where(_filter)))
                {
                    Cells = _board.Where(_filter);
                }

                return Cells != null;
            }
        }


        protected WinningState(IBoard board, Func<ICell, bool> filter)
        {
            _board = board;
            _filter = filter;
        }


        protected bool CellsFilledWithFiguresOfOneType(IEnumerable<ICell> cells)
        {
            var cellsArray = cells.ToArray();

            return cellsArray.All(cell => !cell.IsEmpty && cell.Figure.Type == cellsArray[0].Figure.Type);
        }
    }
}