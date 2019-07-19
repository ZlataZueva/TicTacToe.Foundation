using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class VerticalRow : WinningState
    {
        public VerticalRow()
        : base(WinningStateType.VerticalRow)
        {

        }


        public override bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells)
        {
            winningCells = Enumerable.Range(0, board.Size)
                .Select(column => board.Where(cell => cell.Column == column))
                .FirstOrDefault(CellsFilledWithFiguresOfOneType);
            
            return winningCells != null;
        }
    }
}