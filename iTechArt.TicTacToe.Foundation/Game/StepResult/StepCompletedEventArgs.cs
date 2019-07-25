using System;

namespace iTechArt.TicTacToe.Foundation.Game.StepResult
{
    public class StepCompletedEventArgs : EventArgs
    {
        public StepResult Result { get; }


        public StepCompletedEventArgs(StepResult result)
        {
            Result = result;
        }
    }
}