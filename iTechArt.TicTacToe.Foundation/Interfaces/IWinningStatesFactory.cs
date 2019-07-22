using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IWinningStatesFactory
    {
        IReadOnlyCollection<IWinningState> CreateWinningStates(IBoard board);
    }
}