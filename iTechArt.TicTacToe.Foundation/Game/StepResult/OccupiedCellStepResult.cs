using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game.StepResult
{
    public class OccupiedCellStepResult : StepResult
    {
        public ICell Cell { get; }


        public OccupiedCellStepResult(ICell cell) 
            : base(StepResultType.OccupiedCell)
        {
            Cell = cell;
        }
    }
}