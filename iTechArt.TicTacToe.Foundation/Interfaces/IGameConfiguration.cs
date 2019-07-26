using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfiguration
    {
        IReadOnlyCollection<IPlayer> Players { get; }

        int FirstPlayerIndex { get; }

        int BoardSize { get; }
    }
}