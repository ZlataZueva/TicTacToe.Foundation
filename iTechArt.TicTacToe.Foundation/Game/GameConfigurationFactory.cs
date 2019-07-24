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
            if (uniquePlayers.Select(p => p.FigureType).Distinct().Count() != 1)
            {
                throw new ArgumentException("Players should have unique figure types");
            }
            
            return new GameConfiguration(uniquePlayers, uniquePlayers.IndexOf(firstPlayer), boardSize);
        }
    }
}