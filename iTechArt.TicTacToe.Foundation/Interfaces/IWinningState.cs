using System.Collections.Generic;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IWinningState
    {
        bool IsPresent { get; }

        IEnumerable<ICell>  Cells { get; }
    }
}