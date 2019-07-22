using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IWinningState
    {
        bool IsActive { get; }

        IReadOnlyCollection<ICell>  Cells { get; }
    }
}