using iTechArt.TicTacToe.Foundation.Board;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        IBoard Board { get; }

        IPlayer CurrentPlayer { get; }

        bool IsFinished { get; }

        IPlayer Winner { get; }


        void Start();

        FillCellResult MakeMove(int row, int column);
    }
}