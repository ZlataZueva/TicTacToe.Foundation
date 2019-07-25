using System;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Players
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string firstName, string lastName, FigureType figureType)
        {
            if (firstName == string.Empty || lastName == string.Empty)
            {
                throw new ArgumentException("Player's first and last names should not be empty");
            }

            return new Player(firstName, lastName, figureType);
        }
    }
}