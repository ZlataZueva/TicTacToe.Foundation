using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private bool? _isActive;


        public IReadOnlyCollection<ICell> Cells { get; }

        public bool IsActive => _isActive ?? (_isActive = CheckIfActive()) ?? false;


        protected WinningState(IBoard board, Func<ICell, bool> filter)
        {
            Cells = board.Where(filter).ToList();
        }


        private bool? CheckIfActive()
        {
            var figureTypesCount = Cells.Where(c => !c.IsEmpty)
                .Select(c => c.Figure.Type).Distinct().Count();
            if (figureTypesCount > 1)
            {
                return false;
            }
            if (Cells.All(c => !c.IsEmpty))
            {
                return true;
            }

            return null;
        }
    }
}