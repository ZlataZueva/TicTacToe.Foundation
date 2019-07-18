using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class DiagonalRow : WinningState
    {
        public DiagonalRow()
        : base(WinningStateType.Diagonal)
        {

        }

        
        public override bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells)
        {
            winningCells = null;
            var mainDiagonalCells = board.Where(cell => cell.Row == cell.Column);
            if (AreFigureTypesEqual(mainDiagonalCells))
            {
                winningCells = mainDiagonalCells;

                return true;
            }

            var sideDiagonalCells = board.Where(cell => cell.Row == board.Size - cell.Column - 1);
            if (AreFigureTypesEqual(sideDiagonalCells))
            {
                winningCells = sideDiagonalCells;

                return true;
            }

            return false;
        }
    }
}