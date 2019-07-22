using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class FilledColumn : WinningState
    {
        public FilledColumn(IBoard board, int number)
            : base(board, cell => cell.Column == number)
        {

        }
    }
}