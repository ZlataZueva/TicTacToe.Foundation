﻿using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Game
{
    public abstract class GameResult : IGameResult
    {
        public GameResultType Type { get; }


        protected GameResult(GameResultType type)
        {
            Type = type;
        }
    }
}