using System;

namespace iTechArt.TicTacToe.Foundation.Interfaces
{
    public interface IGameUser
    {
        Tuple<int,int> GetPositionToMakeMove(IPlayer player);

        void ShowError(string message);
    }
}