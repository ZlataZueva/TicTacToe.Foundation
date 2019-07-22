using iTechArt.TicTacToe.Foundation.Game;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        IBoard Board { get; }

        IPlayer CurrentPlayer { get; }

        bool IsFinished { get; }

        IPlayer Winner { get; }


        void Start();

        MoveResult MakeMove(int row, int column);
    }
}