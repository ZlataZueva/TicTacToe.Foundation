using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Extensions;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class Game : IGame
    {
        private readonly IGameInputProvider _gameInputProvider;

        private readonly IReadOnlyCollection<IPlayer> _players;
        private readonly IBoard _board;
        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private int _currentPlayerIndex;


        private IPlayer CurrentPlayer => _players.ElementAt(_currentPlayerIndex);


        public event EventHandler<GameStepCompletedEventArgs> GameStepCompleted;

        public event EventHandler<GameStepFinishedEventArgs> GameStepFinished;


        public Game(
            IGameConfiguration gameConfiguration,
            IBoardFactory boardFactory,
            IWinningStatesFactory winningStatesFactory,
            IGameInputProvider gameInputProvider)
        {
            _gameInputProvider = gameInputProvider;

            _players = gameConfiguration.Players;
            _board = boardFactory.CreateBoard(gameConfiguration.BoardSize);
            _winningStates = winningStatesFactory.CreateWinningStates(_board);
            _currentPlayerIndex = gameConfiguration.FirstPlayerIndex;
        }


        public IGameResult Run()
        {
            while (!_board.IsFilled)
            {
                MakeMove(CurrentPlayer);
                var winningState = _winningStates.SingleOrDefault(state => state.IsActive);
                if (winningState != null)
                {
                    OnGameStepFinished(new GameStepFinishedEventArgs(_board, StepResult.GameEnd));

                    return new Win(CurrentPlayer);
                }
                if (!_board.IsFilled)
                {
                    OnGameStepFinished(new GameStepFinishedEventArgs(_board, StepResult.NextTurn));
                }
                else
                {
                    MoveToNextPlayer();
                }
            }
            OnGameStepFinished(new GameStepFinishedEventArgs(_board, StepResult.GameEnd));

            return new Draw();
        }
        

        protected void OnGameStepCompleted(GameStepCompletedEventArgs e)
        {
           e.Raise(GameStepCompleted, this);
        }

        protected void OnGameStepFinished(GameStepFinishedEventArgs e)
        {
            e.Raise(GameStepFinished, this);
        }


        private void MoveToNextPlayer()
        {
            _currentPlayerIndex++;
            _currentPlayerIndex %= _players.Count;
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