using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private readonly IEqualityComparer<ICell> _cellsComparer;


        private IEnumerable<ICell> Cells { get; }


        IEnumerable<ICell> IWinningState.Cells => IsPresent ? Cells : null;
        
        public bool IsPresent => Cells.Distinct(_cellsComparer)
                                      .Count(cell => !cell.IsEmpty) == 1;


        protected WinningState(IBoard board, Func<ICell, bool> filter, IEqualityComparer<ICell> cellsComparer)
        {
            _cellsComparer = cellsComparer;

            Cells = board.Where(filter);
        }
    }
}