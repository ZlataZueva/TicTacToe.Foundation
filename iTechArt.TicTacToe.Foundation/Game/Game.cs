using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Board;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class Game : IGame
    {
        private readonly IGameConfiguration _gameConfiguration;

        private readonly IBoard _board;
        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private int _nextPlayerIndex;


        private IPlayer NextPlayer
        {
            get
            {
                _nextPlayerIndex %= _gameConfiguration.Players.Count;

                return _gameConfiguration.Players.ElementAt(_nextPlayerIndex++);
            }
        }


        public IPlayer CurrentPlayer { get; private set; }


        public event BoardStateChangedHandler BoardStateChanged;

        public event GameFinishHandler GameFinished;


        public Game(IGameConfiguration gameConfiguration,
                    IBoardFactory boardFactory,
                    IWinningStatesFactory winningStatesFactory)
        {
            _gameConfiguration = gameConfiguration;

            _board = boardFactory.CreateBoard(_gameConfiguration.BoardSize);
            _winningStates = winningStatesFactory.CreateWinningStates(_board);
        }


        public void Run()
        {
            CurrentPlayer = NextPlayer;
        }
        

        protected void OnBoardStateChanged(IBoard board)
        {
            BoardStateChanged?.Invoke(board);
        }

        protected void OnGameFinished(IPlayer winner)
        {
            GameFinished?.Invoke(winner);
        }


        private FillCellResult MakeMove(int row, int column)
        {
            var placeResult = _board.PlaceFigure(row, column, CurrentPlayer.FigureType);
            if (placeResult != FillCellResult.Success)
            {
                return placeResult;
            }
            OnBoardStateChanged(_board);
            var winningState = _winningStates.SingleOrDefault(state => state.IsActive);
            if (winningState != null)
            {
                OnGameFinished(CurrentPlayer);
            }
            if (_board.IsFilled)
            {
                OnGameFinished(null);
            }
            else
            {
                CurrentPlayer = NextPlayer;
            }

            return placeResult;
        }
    }
}