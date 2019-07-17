namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface ICellFactory
    {
        ICell CreateCell(IPosition position);
    }
}