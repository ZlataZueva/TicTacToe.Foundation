using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class WinningStatesFactory : IWinningStatesFactory
    {
        public IEnumerable<IWinningState> CreateWinningStates(IBoard board)
        {
            var cellsComparer = new CellsEqualityComparer();

            return Enumerable.Range(0, board.Size)
                .SelectMany(number => new WinningState[]
                {
                    new FilledColumn(board, number, cellsComparer),
                    new FilledRow(board, number, cellsComparer)
                })
                .Append(new FilledMajorDiagonal(board, cellsComparer))
                .Append(new FilledMinorDiagonal(board, cellsComparer));
        }
    }
}