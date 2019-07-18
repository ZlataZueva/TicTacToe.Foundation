using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class VerticalRow : WinningState
    {
        public VerticalRow()
        : base(WinningStateType.Vertical)
        {

        }


        public override bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells)
        {
            winningCells = null;
            foreach (var column in Enumerable.Range(0,board.Size))
            {
                var columnCells = board.Where(cell => cell.Column == column);
                if (AreFilledWithFiguresOfOneType(columnCells))
                {
                    winningCells = columnCells;

                    return true;
                }
            }

            return false;
        }
    }
}