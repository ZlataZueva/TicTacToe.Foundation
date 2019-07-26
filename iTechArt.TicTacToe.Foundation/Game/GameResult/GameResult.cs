namespace iTechArt.TicTacToe.Foundation.Game.GameResult
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