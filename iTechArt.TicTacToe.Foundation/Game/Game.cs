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


        private IPlayer CurrentPlayer { get; set; }
        
        private IPlayer NextPlayer
        {
            get
            {
                _nextPlayerIndex %= _gameConfiguration.Players.Count;

                return _gameConfiguration.Players.ElementAt(_nextPlayerIndex++);
            }
        }


        public event BoardStateChangedHandler BoardStateChanged;


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


        public IGameResult Run()
        {
            while (!_board.IsFilled)
            {
                CurrentPlayer = NextPlayer;
                MakeMove(CurrentPlayer);
                var winningState = _winningStates.SingleOrDefault(state => state.IsActive);
                if (winningState != null)
                {
                    return new Win(CurrentPlayer);
                }
            }

            return new Draw();
        }
        

        protected void OnBoardStateChanged(IBoard board)
        {
            BoardStateChanged?.Invoke(board);
        }


        private void MakeMove(IPlayer player)
        {
            var (row, column) = _gameUser.GetPositionToMakeMove(player);
            var placeResult = _board.PlaceFigure(row, column, player.FigureType);
            while (placeResult != FillCellResult.Success)
            {
                if (placeResult == FillCellResult.NonexistentCell)
                {
                    _gameUser.ShowError("Specified cell doesn't exist");
                }
                if (placeResult == FillCellResult.OccupiedCell)
                {
                    _gameUser.ShowError("Specified cell is occupied");
                }
                (row, column) = _gameUser.GetPositionToMakeMove(player);
                placeResult = _board.PlaceFigure(row, column, player.FigureType);
            }
            OnBoardStateChanged(_board);
        }
    }
}