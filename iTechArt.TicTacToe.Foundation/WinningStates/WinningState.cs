using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private readonly IEqualityComparer<ICell> _cellsComparer;
        
        private readonly IEnumerable<ICell> _cells;


        public IEnumerable<ICell> Cells => IsPresent ? _cells : null;
        
        public bool IsPresent => _cells.Distinct(_cellsComparer)
                                     .Count(cell => !cell.IsEmpty) == 1;


        protected WinningState(IBoard board, Func<ICell, bool> filter, IEqualityComparer<ICell> cellsComparer)
        {
            _cellsComparer = cellsComparer;

            _cells = board.Where(filter);
        }
    }
}