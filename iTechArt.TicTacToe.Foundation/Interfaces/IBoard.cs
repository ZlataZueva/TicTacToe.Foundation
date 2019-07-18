using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IBoard : IEnumerable<ICell>
    {
        int Size { get; }

        bool IsFilled { get; }


        FIllCellResult PlaceFigure(int row, int column, FigureType type);
    }
}