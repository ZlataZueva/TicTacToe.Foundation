namespace iTechArt.TicTacToe.Foundation
{
    public abstract class Figure
    {
        public enum FigureType
        {
            Cross,
            Circle
        }


        public readonly FigureType Type;


        protected Figure (FigureType type)
        {
            Type = type;
        }
    }
}
