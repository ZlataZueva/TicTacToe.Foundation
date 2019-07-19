using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IWinningState
    {
        bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells);
    }
}