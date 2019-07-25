using System;
using iTechArt.TicTacToe.Foundation.Game.Result;

namespace iTechArt.TicTacToe.Foundation.Game
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