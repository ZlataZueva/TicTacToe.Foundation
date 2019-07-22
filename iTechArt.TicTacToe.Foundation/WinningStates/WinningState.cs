using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        public IReadOnlyCollection<ICell> Cells { get; }
        
        public bool IsActive => Cells.Where(c => !c.IsEmpty).Select(c => c.Figure.Type)
                                     .Distinct().Count() == 1;


        protected WinningState(IBoard board, Func<ICell, bool> filter)
        {
            Cells = board.Where(filter).ToList();
        }
    }
}