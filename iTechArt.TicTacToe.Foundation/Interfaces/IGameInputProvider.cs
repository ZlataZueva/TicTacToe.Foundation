namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameInputProvider
    {
        (int, int) GetPositionToMakeMove(IPlayer player);
    }
}