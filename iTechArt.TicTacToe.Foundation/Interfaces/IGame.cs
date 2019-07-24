using iTechArt.TicTacToe.Foundation.Game;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public delegate void BoardStateChangedHandler(IBoard newBoardState);


    public interface IGame
    {
        event BoardStateChangedHandler BoardStateChanged;


        GameResult Run();
    }
}