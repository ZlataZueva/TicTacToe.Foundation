using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class GameFactory : IGameFactory
    {
        private readonly IBoardFactory _boardFactory;
        private readonly IWinningStatesFactory _winningStatesFactory;
        private readonly IGameInputProvider _gameInputProvider;


        public GameFactory(
            IBoardFactory boardFactory, 
            IWinningStatesFactory winningStatesFactory, 
            IGameInputProvider gameInputProvider)
        {
            _boardFactory = boardFactory;
            _winningStatesFactory = winningStatesFactory;
            _gameInputProvider = gameInputProvider;
        }


        public IGame CreateGame(IGameConfiguration gameConfiguration)
        {
            return new Game(gameConfiguration, _boardFactory, _winningStatesFactory, _gameInputProvider);
        }
    }
}