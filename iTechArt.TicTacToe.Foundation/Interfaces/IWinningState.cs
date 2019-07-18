using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.WinningStates;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IWinningState
    {
        WinningStateType Type { get; }


        bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells);
    }
}