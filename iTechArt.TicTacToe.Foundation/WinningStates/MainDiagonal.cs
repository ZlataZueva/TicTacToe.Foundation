using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class MainDiagonal : WinningState
    {
        public MainDiagonal(IBoard board)
        : base(board, cell => cell.Row == cell.Column)
        {

        }
    }
}