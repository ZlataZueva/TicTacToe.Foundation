using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class FilledMajorDiagonal : WinningState
    {
        public FilledMajorDiagonal(IBoard board)
            : base(board, cell => cell.Row == cell.Column)
        {

        }
    }
}