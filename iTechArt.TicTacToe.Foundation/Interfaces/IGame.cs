using System;
using iTechArt.TicTacToe.Foundation.Game;
using iTechArt.TicTacToe.Foundation.Game.GameResults;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<StepCompletedEventArgs> StepCompleted;

        event EventHandler<GameFinishedEventArgs> GameFinished;


        GameResult Run();
    }
}