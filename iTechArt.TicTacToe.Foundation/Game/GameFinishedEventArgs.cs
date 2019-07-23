using System;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameFinishedEventArgs : EventArgs
    {
        public IPlayer Winner { get; }


        public GameFinishedEventArgs(IPlayer winner)
        {
            Winner = winner;
        }
    }
}