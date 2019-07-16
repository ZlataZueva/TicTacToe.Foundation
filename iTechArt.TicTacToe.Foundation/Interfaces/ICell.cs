namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ICell
    {
        bool IsEmpty { get; }


        IFigure PlacedFigure { get; set; }
    }
}