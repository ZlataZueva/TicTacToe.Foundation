using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IWinningStatesFactory
    {
        IEnumerable<IWinningState> CreateWinningStates(IBoard board);
    }
}