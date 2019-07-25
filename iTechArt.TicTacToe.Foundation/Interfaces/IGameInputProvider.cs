namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameInputProvider
    {
        (int row, int column) GetPositionToMakeMove(IPlayer player);
    }
}