using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal static class Opponent
    {
        public static Board MakeRandomMove(Board board)
        {
            var possibleMoves = board.GetPossibleMoves();
            if (!possibleMoves.Any())
                throw new Exception($"{nameof(Opponent)} cannot perform {nameof(MakeRandomMove)} as there are no possible moves");
            var randomChoice = possibleMoves[new Random().Next(possibleMoves.Count() - 1)];

            var newFieldState = FieldState.Opponent;
            return board.MakeMove(randomChoice, newFieldState);
        }
    }
}
