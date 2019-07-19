using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class HorizontalRow : WinningState
    {
        public HorizontalRow()
        : base(WinningStateType.HorizontalRow)
        {

        }


        public override bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells)
        {
            winningCells = Enumerable.Range(0, board.Size)
                .Select(row => board.Where(cell => cell.Row == row))
                .FirstOrDefault(CellsFilledWithFiguresOfOneType);

            return winningCells != null;
        }
    }
}