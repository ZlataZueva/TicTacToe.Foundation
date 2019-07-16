namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ICell
    {
        IPosition Position { get; }

        bool IsEmpty { get; }
        
        
        IFigure PlacedFigure { get; set; }
    }
}