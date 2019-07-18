using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class HorizontalRow : WinningState
    {
        public HorizontalRow()
        : base(WinningStateType.Horizontal)
        {

        }


        public override bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells)
        {
            winningCells = null;
            foreach(var row in Enumerable.Range(0,board.Size))
            {
                var rowCells = board.Where(cell => cell.Row == row);
                if (AreFigureTypesEqual(rowCells))
                {
                    winningCells = rowCells;

                    return true;
                }
            }

            return false;
        }
    }
}