using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameConfiguration
    {
        ICollection<IPlayer> Players { get; }

        IPlayer NextPlayer { get; }

        int BoardSize { get; }
    }
}