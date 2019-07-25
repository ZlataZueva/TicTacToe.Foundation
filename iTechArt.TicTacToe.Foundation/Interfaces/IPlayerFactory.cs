using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string firstName, string lastName, FigureType figureType);
    }
}