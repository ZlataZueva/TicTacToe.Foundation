using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Figures;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IRegistrationInputProvider
    {
        FigureType ChooseFigureType(ICollection<FigureType> availableFigureTypes);
    }
}