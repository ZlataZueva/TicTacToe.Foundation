using System;
using iTechArt.TicTacToe.Foundation.Board;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameStepCompletedEventArgs : EventArgs
    {
        public FillCellResult FillCellResult { get; }


        public GameStepCompletedEventArgs(FillCellResult fillCellResult)
        {
            FillCellResult = fillCellResult;
        }
    }
}