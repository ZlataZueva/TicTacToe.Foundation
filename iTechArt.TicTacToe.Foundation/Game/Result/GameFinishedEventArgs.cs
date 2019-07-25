using System;

namespace iTechArt.TicTacToe.Foundation.Game.Result
{
    public class GameFinishedEventArgs : EventArgs
    {
        public GameResult Result { get; }


        public GameFinishedEventArgs(GameResult result)
        {
            Result = result;
        }
    }
}