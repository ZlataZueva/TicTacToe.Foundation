using System;
using System.Collections.Generic;
using System.Linq;
using iTechArt.TicTacToe.Foundation.Interfaces;

namespace iTechArt.TicTacToe.Foundation.WinningStates
{
    public class DiagonalRow : WinningState
    {
        public DiagonalRow()
        : base(WinningStateType.DiagonalRow)
        {

        }

        
        public override bool IsPresentOnBoard(IBoard board, out IEnumerable<ICell> winningCells)
        {
            if (board != null)
            {
                var diagonals = new[]
                {
                    board.Where(cell => cell.Row == cell.Column),
                    board.Where(cell => cell.Row == board.Size - cell.Column - 1)
                };
                winningCells = diagonals.FirstOrDefault(CellsFilledWithFiguresOfOneType);

                return winningCells != null;
            }

            throw  new ArgumentNullException(nameof(board));
        }
    }
}