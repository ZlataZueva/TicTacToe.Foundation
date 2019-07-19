using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class Row : WinningState
    {
        public int Number { get; }


        public Row(IBoard board, int number)
        : base(board, cell => cell.Row == number)
        {
            Number = number;
        }
    }
}