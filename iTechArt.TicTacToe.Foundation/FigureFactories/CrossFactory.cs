using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.FigureFactories
{
    class CrossFactory : IFigureFactory
    {
        public IFigure CreateFigure()
        {

            return new Cross();
        }
    }
}