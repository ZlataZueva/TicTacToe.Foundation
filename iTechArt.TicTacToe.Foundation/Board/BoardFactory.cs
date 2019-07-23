using iTechArt.TicTacToe.Foundation.Cell;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    public class BoardFactory : IBoardFactory
    {
        public IBoard CreateBoard(int size)
        {
            return new Board(size, new CellFactory(), new FigureFactory());
        }
    }
}