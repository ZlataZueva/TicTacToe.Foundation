namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    internal interface IFigureSettableCell : ICell
    {
        new IFigure Figure { get; set; }
    }
}