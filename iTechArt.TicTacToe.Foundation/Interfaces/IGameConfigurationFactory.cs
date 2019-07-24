using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfigurationFactory
    {
        IGameConfiguration CreateGameConfiguration(
            IReadOnlyCollection<IPlayer> players, 
            int firstPlayerIndex, 
            int boardSize);
    }
}