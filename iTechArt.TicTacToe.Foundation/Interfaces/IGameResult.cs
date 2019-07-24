namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameResult
    {
        bool IsDraw { get; }

        IPlayer Winner { get; }
    }
}