using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class HorizontalRow : WinningState
    {
        public HorizontalRow()
        : base()
        {

        }


        public override bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells)
        {
            if (board != null)
            {
                winningCells = Enumerable.Range(0, board.Size)
                    .Select(row => board.Where(cell => cell.Row == row))
                    .FirstOrDefault(CellsFilledWithFiguresOfOneType);

                return winningCells != null;
            }

            throw new ArgumentNullException(nameof(board));
        }
    }
}