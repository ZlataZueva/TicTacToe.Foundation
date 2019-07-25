using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameConfigurationFactory : IGameConfigurationFactory
    {
        public IGameConfiguration CreateGameConfiguration(
            IReadOnlyCollection<IPlayer> players, 
            int firstPlayerIndex, 
            int boardSize)
        {
            var uniquePlayers = players.Distinct().ToList();
            if (uniquePlayers.Count != players.Count)
            {
                throw new ArgumentException("Players collection contains duplicates");
            }
            if (uniquePlayers.Count < 2)
            {
                throw new ArgumentException("Number of players is less then 2");
            }
            if (uniquePlayers.Select(p => p.FigureType).Distinct().Count() != uniquePlayers.Count)
            {
                throw new ArgumentException("Each player should have unique figure type");
            }
            if (firstPlayerIndex < 0 || firstPlayerIndex >= uniquePlayers.Count)
            {
                throw new ArgumentException("First player index is less than 0 or greater than or equal to the number of players.");
            }
            
            return new GameConfiguration(uniquePlayers, firstPlayerIndex, boardSize);
        }
    }
}