using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Cell
{
    public class CellFactory : ICellFactory
    {
        public ICell CreateCell(int row, int column)
        {
            
            return new Cell(row, column);
        }
    }
}