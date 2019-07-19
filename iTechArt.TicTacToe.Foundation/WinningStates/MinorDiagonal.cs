using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class MinorDiagonal : WinningState
    {
        public MinorDiagonal(IBoard board)
            : base(board, cell => cell.Row == board.Size - cell.Column - 1)
        {

        }
    }
}