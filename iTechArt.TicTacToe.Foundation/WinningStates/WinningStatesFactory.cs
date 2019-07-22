using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class WinningStatesFactory : IWinningStatesFactory
    {
        public IReadOnlyCollection<IWinningState> CreateWinningStates(IBoard board)
        {
            var columns = Enumerable.Range(0, board.Size).Select<int, IWinningState>(n => new FilledColumn(board, n));
            var rows = Enumerable.Range(0, board.Size).Select<int, IWinningState>(n => new FilledRow(board, n));
            var diagonals = new IWinningState[] {new FilledMajorDiagonal(board), new FilledMinorDiagonal(board)};

            return columns.Concat(rows).Concat(diagonals).ToList();
        }
    }
}