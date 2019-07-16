using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    public class Cell : ICell
    {
        public int Row { get; }

        public int Column { get; }

        public bool IsEmpty => PlacedFigure == null;
        

        public IFigure PlacedFigure { get; set; }


        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}