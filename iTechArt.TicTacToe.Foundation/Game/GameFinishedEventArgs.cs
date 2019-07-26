using System;
using Result = iTechArt.TicTacToe.Foundation.Game.GameResult.GameResult;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameFinishedEventArgs : EventArgs
    {
        public Result Result { get; }


        public GameFinishedEventArgs(Result result)
        {
            Result = result;
        }
    }
}