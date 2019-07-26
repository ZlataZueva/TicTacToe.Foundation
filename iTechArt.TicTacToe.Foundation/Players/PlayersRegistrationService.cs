using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Figures;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Players
{
    public class PlayersRegistrationService : IPlayersRegistrationService
    {
        private readonly IRegistrationInputProvider _registrationInputProvider;
        private readonly IPlayerFactory _playerFactory;

        private readonly ICollection<FigureType> _availableFigureTypes;


        public ICollection<IPlayer> Players { get; }


        public PlayersRegistrationService(IRegistrationInputProvider registrationInputProvider, IPlayerFactory playerFactory)
        {
            _registrationInputProvider = registrationInputProvider;
            _playerFactory = playerFactory;

            _availableFigureTypes = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
            Players = new List<IPlayer>();
        }


        public RegistrationResult Register(string firstName, string lastName)
        {
            if (_availableFigureTypes.Count == 0)
            {
                return RegistrationResult.NoMoreFigures;
            }
            if (firstName == string.Empty || lastName == string.Empty)
            {
                return RegistrationResult.NameIsEmpty;
            }
            if (firstName.ToCharArray().Any(char.IsDigit) || lastName.ToCharArray().Any(char.IsDigit))
            {
                return RegistrationResult.NameContainsDigit;
            }
            var figureType = _availableFigureTypes.Count == 1? _availableFigureTypes.First() : default;
            while (!_availableFigureTypes.Contains(figureType))
            {
                figureType = _registrationInputProvider.ChooseFigureType(_availableFigureTypes.ToList());
            }
            Players.Add(_playerFactory.CreatePlayer(firstName, lastName, figureType));
            _availableFigureTypes.Remove(figureType);

            return RegistrationResult.Success;
        }
    }
}