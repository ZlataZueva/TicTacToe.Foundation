using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    public class Point : IPosition
    {
        public int Row { get; }

        public int Column { get; }


        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}