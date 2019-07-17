namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IBoard
    {
        int Size { get; }

        bool IsFilled { get; }


        void PlaceFigure(int row, int column, IFigure figure);
    }
}