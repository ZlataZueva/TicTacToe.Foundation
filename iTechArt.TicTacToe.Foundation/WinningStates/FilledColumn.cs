using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class FilledColumn : WinningState
    {
        public int Number { get; }


        public FilledColumn(IBoard board, int number, IEqualityComparer<ICell> cellsComparer)
        : base(board, cell => cell.Column == number, cellsComparer)
        {
            Number = number;
        }
    }
}