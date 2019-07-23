namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public delegate void BoardStateChangedHandler(IBoard newBoardState);

    public delegate void GameFinishHandler(IPlayer winner);


    public interface IGame
    {
        event BoardStateChangedHandler BoardStateChanged;

        event GameFinishHandler GameFinished;


        void Run();
    }
}