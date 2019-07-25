using System;
using iTechArt.TicTacToe.Foundation.Game;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<StepCompletedEventArgs> StepCompleted;

        event EventHandler<GameFinishedEventArgs> GameFinished;


        IGameResult Run();
    }
}