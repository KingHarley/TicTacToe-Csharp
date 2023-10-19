using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    enum FieldState
    {
        Empty,
        Player,
        Opponent
    }

    enum ActivePlayer
    {
        Player,
        Opponent
    }

    internal class Board
    {
        readonly FieldState[,] BoardState;

        public static Board CreateNewBoard() =>
            new Board(new FieldState[3, 3]);

        private Board(FieldState[,] boardState)
        {
            BoardState = boardState;
        }

        public Board MakeRandomMove(ActivePlayer player)
        {
            var newBoard = new Board(BoardState);
            var emptySpace = new List<(int i, int j)>();
            foreach (var i in Enumerable.Range(0, (int)BoardState.GetLongLength(0)))
                foreach(var j in Enumerable.Range(0, (int)BoardState.GetLongLength(1)))
                {
                    if (BoardState[i, j] == FieldState.Empty)
                        emptySpace.Add((i, j));
                }
            if (!emptySpace.Any())
                throw new Exception($"Board has no empty spaces and thus a random move can't be made");
            var randomChoice = emptySpace[new Random().Next(emptySpace.Count() - 1)];
#pragma warning disable 8524
            var newFieldState = player switch
            {
                ActivePlayer.Player => FieldState.Player,
                ActivePlayer.Opponent => FieldState.Opponent
            };
#pragma warning restore 8524

            newBoard.BoardState[randomChoice.i, randomChoice.j] = newFieldState;
            return newBoard;
        }
    }
}