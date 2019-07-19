using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IBoard : IEnumerable<ICell>
    {
        int Size { get; }

        bool IsFilled { get; }


        ICell this[int row, int column] { get; }


        FillCellResult PlaceFigure(int row, int column, FigureType type);
    }
}