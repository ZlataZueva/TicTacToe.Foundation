using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        public WinningStateType Type { get; }


        protected WinningState(WinningStateType type)
        {
            Type = type;
        }


        protected bool AreFigureTypesEqual(IEnumerable<ICell> cells)
        {
            var cellsArray = cells.ToArray();

            return cellsArray.All(cell => !cell.IsEmpty && cell.Figure.Type == cellsArray.First().Figure.Type);
        }

        
        public abstract bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells);
    }
}