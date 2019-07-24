using System;
using iTechArt.TicTacToe.Foundation.Game;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<GameStepCompletedEventArgs> GameStepCompleted;

        event EventHandler<GameStepFinishedEventArgs> GameStepFinished;

        IGameResult Run();
    }
}