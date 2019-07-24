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
        private readonly IGameInputProvider _gameInputProvider;

        private readonly IBoard _board;
        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private int _nextPlayerIndex;


        private IPlayer CurrentPlayer { get; set; }
        
        private IPlayer NextPlayer
        {
            get
            {
                _nextPlayerIndex %= _gameConfiguration.Players.Count;

                return _gameConfiguration.Players.ElementAt(_nextPlayerIndex++);
            }
        }


        public event EventHandler<GameStepCompletedEventArgs> GameStepCompleted;

        public event EventHandler<GameStepFinishedEventArgs> GameStepFinished;


        public Game(IGameConfiguration gameConfiguration,
                    IBoardFactory boardFactory,
                    IWinningStatesFactory winningStatesFactory,
                    IGameInputProvider gameInputProvider)
        {
            _gameConfiguration = gameConfiguration;
            _gameInputProvider = gameInputProvider;

            _board = boardFactory.CreateBoard(_gameConfiguration.BoardSize);
            _winningStates = winningStatesFactory.CreateWinningStates(_board);
            _nextPlayerIndex = _gameConfiguration.FirstPlayerIndex;
        }


        public IGameResult Run()
        {
            while (!_board.IsFilled)
            {
                CurrentPlayer = NextPlayer;
                MakeMove(CurrentPlayer);
                var winningState = _winningStates.SingleOrDefault(state => state.IsActive);
                if (winningState != null)
                {
                    OnGameStepFinished(new GameStepFinishedEventArgs(_board, ResultType.Win));

                    return new Win(CurrentPlayer);
                }
                if (!_board.IsFilled)
                {
                    OnGameStepFinished(new GameStepFinishedEventArgs(_board, ResultType.NextTurn));
                }
            }
            OnGameStepFinished(new GameStepFinishedEventArgs(_board, ResultType.Draw));

            return new Draw();
        }
        

        protected void OnGameStepCompleted(GameStepCompletedEventArgs e)
        {
            GameStepCompleted?.Invoke(this, e);
        }

        protected void OnGameStepFinished(GameStepFinishedEventArgs e)
        {
            GameStepFinished?.Invoke(this, e);
        }


        private void MakeMove(IPlayer player)
        {
            FillCellResult fillCellResult;
            do
            {
                var (row, column) = _gameInputProvider.GetPositionToMakeMove(player);
                fillCellResult = _board.PlaceFigure(row, column, player.FigureType);
                OnGameStepCompleted(new GameStepCompletedEventArgs(fillCellResult));
            } while (fillCellResult != FillCellResult.Success);
        }
    }
}