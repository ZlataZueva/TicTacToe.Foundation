using System;
using iTechArt.TicTacToe.Foundation.Game.StepResults;

namespace iTechArt.TicTacToe.Foundation.Game
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