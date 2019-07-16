namespace iTechArt.TicTacToe.Foundation.Figures
{
    public abstract class Figure
    {
        public FigureType Type { get; }


        protected Figure(FigureType type)
        {
            Type = type;
        }
    }
}