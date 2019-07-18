using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Figures
{
    public abstract class Figure : IFigure
    {
        public FigureType Type { get; }


        protected Figure(FigureType type)
        {
            Type = type;
        }
    }
}