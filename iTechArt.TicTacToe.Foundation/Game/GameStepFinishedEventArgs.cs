using System;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameStepFinishedEventArgs : EventArgs
    {
        public IBoard BoardState { get; }

        public StepResult StepResult { get; }


        public GameStepFinishedEventArgs(IBoard boardState, StepResult stepResult)
        {
            BoardState = boardState;
            StepResult = stepResult;
        }
    }
}