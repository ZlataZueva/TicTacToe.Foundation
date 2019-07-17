namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ICell
    {
        int Row { get; }

        int Column { get; }

        bool IsEmpty { get; }
        
        IFigure Figure { get; set; }
    }
}