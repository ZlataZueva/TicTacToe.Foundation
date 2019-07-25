﻿using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class SuccessfulStepResult : StepResult
    {
        public IBoard NewBoardState { get; }


        public SuccessfulStepResult(IBoard newBoardState) 
            : base(StepResultType.Success)
        {
            NewBoardState = newBoardState;
        }
    }
}