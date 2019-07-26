namespace iTechArt.TicTacToe.Foundation.Game.GameResults
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