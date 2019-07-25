namespace iTechArt.TicTacToe.Foundation.Game
{
    public abstract class StepResult
    {
        public StepResultType Type { get; }


        protected StepResult(StepResultType type)
        {
            Type = type;
        }
    }
}