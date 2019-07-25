namespace iTechArt.TicTacToe.Foundation.Game.Result
{
    public abstract class GameResult
    {
        public GameResultType Type { get; }


        protected GameResult(GameResultType type)
        {
            Type = type;
        }
    }
}