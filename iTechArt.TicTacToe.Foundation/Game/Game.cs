using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.Board;
using iTechArt.TicTacToe.Foundation.Extensions;
using iTechArt.TicTacToe.Foundation.Game.Result;

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


        public event EventHandler<StepCompletedEventArgs> StepCompleted;

        public event EventHandler<GameFinishedEventArgs> GameFinished;


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
                    var winningResult = new WinningGameResult(CurrentPlayer);
                    OnGameFinished(new GameFinishedEventArgs(winningResult));

                    return winningResult;
                }
                MoveToNextPlayer();
            }
            var drawResult = new DrawGameResult();
            OnGameFinished(new GameFinishedEventArgs(drawResult));

            return drawResult;
        }
        

        protected void OnStepCompleted(StepCompletedEventArgs e)
        {
           StepCompleted.Raise(this, e);
        }

        protected void OnGameFinished(GameFinishedEventArgs e)
        {
            GameFinished.Raise(this, e);
        }


        private void MoveToNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex+1) % _players.Count;
        }

        private void MakeMove(IPlayer player)
        {
            FillCellResult fillCellResult;
            do
            {
                var (row, column) = _gameInputProvider.GetPositionToMakeMove(player);
                fillCellResult = _board.PlaceFigure(row, column, player.FigureType);
                switch (fillCellResult)
                {
                    case FillCellResult.Success:
                        OnStepCompleted(new StepCompletedEventArgs(new SuccessfulStepResult(_board)));
                        break;
                    case FillCellResult.NonexistentCell:
                        OnStepCompleted(new StepCompletedEventArgs(new NonexistentCellStepResult()));
                        break;
                    case FillCellResult.OccupiedCell:
                        OnStepCompleted(new StepCompletedEventArgs(new OccupiedCellStepResult(_board[row,column])));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(fillCellResult), fillCellResult, "Unknown fill cell result");
                }
            } while (fillCellResult != FillCellResult.Success);
        }
    }
}