using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameConfiguration : IGameConfiguration
    {
        public IReadOnlyCollection<IPlayer> Players { get; }

        public int FirstPlayerIndex { get; }

        public int BoardSize { get; }

        
        public GameConfiguration(IReadOnlyCollection<IPlayer> players, int firstPlayerIndex, int boardSize)
        {
            Players = players;
            FirstPlayerIndex = firstPlayerIndex;
            BoardSize = boardSize;
        }
    }
}