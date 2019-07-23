﻿using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;
using iTechArt.TicTacToe.Foundation.GameBoard;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public class Game : IGame
    {
        private readonly IGameConfiguration _gameConfiguration;
        private readonly int _playersAmount;

        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private int _nextPlayerIndex;


        private IPlayer NextPlayer
        {
            get
            {
                _nextPlayerIndex %= _playersAmount;

                return _gameConfiguration.Players.ElementAt(_nextPlayerIndex++);
            }
        }


        public IBoard Board { get; }

        public IPlayer CurrentPlayer { get; private set; }

        public bool IsFinished { get; private set; }

        public IPlayer Winner { get; private set; }

        
        public Game(IGameConfiguration gameConfiguration, ICellFactory cellFactory, 
            IFigureFactory figureFactory, IWinningStatesFactory winningStatesFactory)
        {
            _gameConfiguration = gameConfiguration;

            Board = new Board(gameConfiguration.BoardSize, cellFactory, figureFactory);
            _playersAmount = _gameConfiguration.Players.Count();
            _winningStates = winningStatesFactory.CreateWinningStates(Board);
        }

        
        public void Start()
        {
            CurrentPlayer = NextPlayer;
        }

        public FillCellResult MakeMove(int row, int column)
        {
            var placeResult = Board.PlaceFigure(row, column, CurrentPlayer.FigureType);
            if (placeResult != FillCellResult.Success)
            {
                return placeResult;
            }
            var winningState = _winningStates.SingleOrDefault(state => state.IsActive);
            if (winningState != null)
            {
                IsFinished = true;
                Winner = CurrentPlayer;
            }
            if (Board.IsFilled)
            {
                IsFinished = true;
            }
            else
            {
                CurrentPlayer = NextPlayer;
            }

            return placeResult;
        }
    }
}