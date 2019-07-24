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

        public bool IsActive
        {
            get
            {
                if (_isActive.HasValue)
                {
                    return _isActive.Value;
                }
                var figureTypesCount = Cells.Where(c => !c.IsEmpty)
                    .Select(c => c.Figure.Type).Distinct().Count();
                if (figureTypesCount > 1)
                {
                    _isActive = false;
                }
                else if (Cells.All(c => !c.IsEmpty))
                {
                    _isActive = true;
                }

                return _isActive ?? false;
            }
        } 


        protected WinningState(IBoard board, Func<ICell, bool> filter)
        {
            Cells = board.Where(filter).ToList();
        }
    }
}