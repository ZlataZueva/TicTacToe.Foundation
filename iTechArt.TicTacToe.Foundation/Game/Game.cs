using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Board;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class Game : IGame
    {
        private readonly IGameConfiguration _gameConfiguration;
        private readonly IGameUser _gameUser;

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
                    IWinningStatesFactory winningStatesFactory,
                    IGameUser gameUser)
        {
            _gameConfiguration = gameConfiguration;
            _gameUser = gameUser;

            _board = boardFactory.CreateBoard(_gameConfiguration.BoardSize);
            _winningStates = winningStatesFactory.CreateWinningStates(_board);
            _nextPlayerIndex = _gameConfiguration.FirstPlayerIndex;
        }


        public void Run()
        {
            CurrentPlayer = NextPlayer;
            var (row, column) = _gameUser.GetPositionToMakeMove(CurrentPlayer);
            var moveResult = MakeMove(row, column);
            while (moveResult != MoveResult.NextTurn && moveResult != MoveResult.GameFinish)
            {
                _gameUser.ShowError(moveResult == MoveResult.NonexistentCell
                    ? "Specified cell doesn't exist"
                    : "Specified cell is occupied");
                (row, column) = _gameUser.GetPositionToMakeMove(CurrentPlayer);
                moveResult = MakeMove(row, column);
            }
        }
        

        protected void OnBoardStateChanged(IBoard board)
        {
            BoardStateChanged?.Invoke(board);
        }

        protected void OnGameFinished(IPlayer winner)
        {
            GameFinished?.Invoke(winner);
        }


        private MoveResult MakeMove(int row, int column)
        {
            var placeResult = _board.PlaceFigure(row, column, CurrentPlayer.FigureType);
            if (placeResult != FillCellResult.Success)
            {
                return placeResult == FillCellResult.NonexistentCell
                    ? MoveResult.NonexistentCell
                    : MoveResult.OccupiedCell;
            }
            OnBoardStateChanged(_board);
            var winningState = _winningStates.SingleOrDefault(state => state.IsActive);
            if (winningState != null)
            {
                OnGameFinished(CurrentPlayer);
            }
            else if (_board.IsFilled)
            {
                OnGameFinished(null);
            }
            else
            {
                CurrentPlayer = NextPlayer;

                return MoveResult.NextTurn;
            }

            return MoveResult.GameFinish;
        }
    }
}