using System;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class BoardStateChangedEventArgs : EventArgs
    {
        public IBoard NewBoardState { get; }


        public BoardStateChangedEventArgs(IBoard newBoardState)
        {
            NewBoardState = newBoardState;
        }
    }
}