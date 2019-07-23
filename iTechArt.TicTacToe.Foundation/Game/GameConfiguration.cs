using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameConfiguration : IGameConfiguration
    {
        public IReadOnlyCollection<IPlayer> Players { get; }

        public int BoardSize { get; }

        
        public GameConfiguration(IEnumerable<IPlayer> players, int boardSize)
        {
            Players = players.ToList();
            BoardSize = boardSize;
        }
    }
}