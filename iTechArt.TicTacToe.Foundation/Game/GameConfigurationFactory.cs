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
            var firstPlayer = players.ElementAt(firstPlayerIndex);
            var uniquePlayers = players.Distinct().ToList();
            if (uniquePlayers.Count < 2)
            {
                throw new ArgumentException("Number of players should be 2 or more");
            }
            if (uniquePlayers.Select(p => p.FigureType).Distinct().Count() != uniquePlayers.Count)
            {
                throw new ArgumentException("Each player should have unique figure type");
            }
            
            return new GameConfiguration(uniquePlayers, uniquePlayers.IndexOf(firstPlayer), boardSize);
        }
    }
}