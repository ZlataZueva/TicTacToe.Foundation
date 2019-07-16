namespace iTechArt.TicTacToe.Foundation
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