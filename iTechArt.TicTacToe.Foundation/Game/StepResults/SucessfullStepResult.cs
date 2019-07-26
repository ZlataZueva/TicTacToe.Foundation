using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game.StepResults
{
    public class SuccessfulStepResult : StepResult
    {
        public IBoard Board { get; }


        public SuccessfulStepResult(IBoard board) 
            : base(StepResultType.Success)
        {
            Board = board;
        }
    }
}