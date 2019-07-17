using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Cell
{
    public class Cell : IFigureSettableCell
    {
        public int Row { get; }

        public int Column { get; }

        public bool IsEmpty => Figure == null;
        
        public IFigure Figure { get; set; }


        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}