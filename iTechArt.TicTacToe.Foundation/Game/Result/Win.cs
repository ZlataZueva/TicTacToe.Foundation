using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game.Result
{
    public class Win : GameResult
    {
        public IPlayer Winner { get; }

        public Win(IPlayer winner)
            : base(GameResultType.Win)
        {
            Winner = winner;
        }
    }
}