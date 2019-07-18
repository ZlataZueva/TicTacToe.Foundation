namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    internal interface ICellInternal : ICell
    {
        new IFigure Figure { set; }
    }
}