using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class FilledColumn : WinningState
    {
        public int Number { get; }


        public FilledColumn(IBoard board, int number)
            : base(board, cell => cell.Column == number)
        {
            Number = number;
        }
    }
}