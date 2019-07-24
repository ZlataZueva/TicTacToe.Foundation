using System;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameStepFinishedEventArgs : EventArgs
    {
        public IBoard BoardState { get; }

        public ResultType ResultType { get; }


        public GameStepFinishedEventArgs(IBoard boardState, ResultType resultType)
        {
            BoardState = boardState;
            ResultType = resultType;
        }
    }
}