using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class Column : WinningState
    {
        public int Number { get; }


        public Column(IBoard board, int number)
        : base(board, cell => cell.Column == number)
        {
            Number = number;
        }
    }
}