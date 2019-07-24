using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class Win : GameResult
    {
        public IPlayer Winner { get; }

        public Win(IPlayer winner)
            : base(ResultType.Win)
        {
            Winner = winner;
        }
    }
}