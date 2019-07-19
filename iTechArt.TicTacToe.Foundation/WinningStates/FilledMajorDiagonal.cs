using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class FilledMajorDiagonal : WinningState
    {
        public FilledMajorDiagonal(IBoard board, IEqualityComparer<ICell> cellsComparer)
        : base(board, cell => cell.Row == cell.Column, cellsComparer)
        {

        }
    }
}