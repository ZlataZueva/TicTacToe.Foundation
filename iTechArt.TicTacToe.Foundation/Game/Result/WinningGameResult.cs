using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game.Result
{
    public class WinningGameResult : GameResult
    {
        public IPlayer Winner { get; }


        public WinningGameResult(IPlayer winner)
            : base(GameResultType.Win)
        {
            Winner = winner;
        }
    }
}