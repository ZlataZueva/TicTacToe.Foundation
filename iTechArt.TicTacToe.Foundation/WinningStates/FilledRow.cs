using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class FilledRow : WinningState
    {
        public int Number { get; }


        public FilledRow(IBoard board, int number, IEqualityComparer<ICell> cellsComparer)
        : base(board, cell => cell.Row == number, cellsComparer)
        {
            Number = number;
        }
    }
}