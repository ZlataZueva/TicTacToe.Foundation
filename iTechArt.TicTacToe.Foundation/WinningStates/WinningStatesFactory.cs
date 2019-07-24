using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class WinningStatesFactory : IWinningStatesFactory
    {
        public IReadOnlyCollection<IWinningState> CreateWinningStates(IBoard board)
        {
            var columns = Enumerable.Range(0, board.Size).Select<int, IWinningState>(c => new FilledColumn(board, c));
            var rows = Enumerable.Range(0, board.Size).Select<int, IWinningState>(r => new FilledRow(board, r));
            var diagonals = new IWinningState[] { new FilledMajorDiagonal(board), new FilledMinorDiagonal(board) };

            return columns.Concat(rows).Concat(diagonals).ToList();
        }
    }
}