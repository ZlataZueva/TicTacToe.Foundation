using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public abstract class GameResult : IGameResult
    {
        public ResultType Type { get; }


        protected GameResult(ResultType type)
        {
            Type = type;
        }
    }
}