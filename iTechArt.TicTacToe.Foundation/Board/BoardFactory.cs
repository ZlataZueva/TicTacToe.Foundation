using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    public class BoardFactory : IBoardFactory
    {
        private readonly ICellFactory _cellFactory;
        private readonly IFigureFactory _figureFactory;


        public BoardFactory(ICellFactory cellFactory, IFigureFactory figureFactory)
        {
            _cellFactory = cellFactory;
            _figureFactory = figureFactory;
        }


        public IBoard CreateBoard(int size)
        {
            return new Board(size,_cellFactory, _figureFactory);
        }
    }
}