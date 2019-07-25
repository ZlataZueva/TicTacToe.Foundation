using System;
using iTechArt.TicTacToe.Foundation.Game.Result;
using iTechArt.TicTacToe.Foundation.Game.StepResult;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<StepCompletedEventArgs> StepCompleted;

        event EventHandler<GameFinishedEventArgs> GameFinished;


        GameResult Run();
    }
}