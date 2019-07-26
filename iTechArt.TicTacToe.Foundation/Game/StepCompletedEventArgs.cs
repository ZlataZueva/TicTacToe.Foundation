using System;
using Result = iTechArt.TicTacToe.Foundation.Game.StepResult.StepResult;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class StepCompletedEventArgs : EventArgs
    {
        public Result Result { get; }


        public StepCompletedEventArgs(Result result)
        {
            Result = result;
        }
    }
}