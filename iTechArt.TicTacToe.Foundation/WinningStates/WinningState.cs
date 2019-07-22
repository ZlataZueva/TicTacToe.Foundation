using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private bool _isPossible;
        private bool _isActivated;


        public IReadOnlyCollection<ICell> Cells { get; }

        public bool IsActive
        {
            get
            {
                if (!_isPossible || _isActivated)
                {
                    return _isActivated;
                }
                var figureTypesCounter = Cells.Where(c => !c.IsEmpty)
                    .Select(c => c.Figure.Type).Distinct().Count();
                if (figureTypesCounter > 1)
                {
                    return _isPossible = false;
                }
                
                return _isActivated = Cells.All(c => !c.IsEmpty);
            }
        } 


        protected WinningState(IBoard board, Func<ICell, bool> filter)
        {
            Cells = board.Where(filter).ToList();

            _isActivated = false;
            _isPossible = true;
        }
    }
}