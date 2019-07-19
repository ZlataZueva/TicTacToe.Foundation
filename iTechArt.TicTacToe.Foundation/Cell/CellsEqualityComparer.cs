using System.Collections.Generic;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.Cell
{
    public class CellsEqualityComparer : IEqualityComparer<ICell>
    {
        public bool Equals(ICell x, ICell y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return !x.IsEmpty && !y.IsEmpty && x.Figure.Type == y.Figure.Type || x.IsEmpty && y.IsEmpty;
        }

        public int GetHashCode(ICell obj)
        {
            var hCode = obj.IsEmpty.GetHashCode() ^ (obj.Figure == null? 0 : obj.Figure.GetHashCode());

            return hCode.GetHashCode();
        }
    }
}