using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class FilledMinorDiagonal : WinningState
    {
        public FilledMinorDiagonal(IBoard board)
            : base(board, cell => cell.Row == board.Size - cell.Column - 1)
        {

        }
    }
}