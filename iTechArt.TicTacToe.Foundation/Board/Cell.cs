using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Board
{
    public class Cell : ICell
    {
        public IPosition Position { get; }

        public bool IsEmpty => PlacedFigure == null;

        
        public IFigure PlacedFigure { get; set; }


        public Cell(IPosition position)
        {
            Position = position;
        }
    }
}