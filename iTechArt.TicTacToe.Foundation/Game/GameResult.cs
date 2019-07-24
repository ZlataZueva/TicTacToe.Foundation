using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameResult : IGameResult
    {
        public IPlayer Winner { get; }

        public bool IsDraw { get; }


        public GameResult(IPlayer winner)
        {
            Winner = winner;
            IsDraw = winner == null;
        }
    }
}