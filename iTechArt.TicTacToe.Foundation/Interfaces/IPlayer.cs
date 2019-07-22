using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IPlayer
    {
        string FirstName { get; }

        string LastName { get; }

        FigureType FigureType { get; }
    }
}