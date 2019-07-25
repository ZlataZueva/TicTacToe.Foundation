using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Players;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IPlayersRegistrationService
    {
        ICollection<IPlayer> Players { get; }


        RegistrationResult Register(string firstName, string lastName);
    }
}