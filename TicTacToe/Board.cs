using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

    enum GameState
    {
        Ongoing,
        PlayerWon,
        OpponentWon,
        Draw
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

        public Board MakeMove(Field move, FieldState newState)
        {
            var state = BoardState[move.Row, move.Column];
            if (state != FieldState.Empty)
                throw new Exception($"Invalid move. Row: {move.Row}, Column: {move.Column} has state {state} which is not {FieldState.Empty}");
            var newBoardState = BoardState;
            newBoardState[move.Row, move.Column] = newState;
            return new Board(newBoardState);
        }

        public Field[] GetPossibleMoves()
        {
            var emptySpace = new List<Field>();
            foreach (var row in Enumerable.Range(0, (int)BoardState.GetLongLength(0)))
                foreach (var col in Enumerable.Range(0, (int)BoardState.GetLongLength(1)))
                {
                    if (BoardState[row, col] == FieldState.Empty)
                        emptySpace.Add(new Field(row, col));
                }
            return emptySpace.ToArray();
        }

        public (FieldState First, FieldState Second, FieldState Third) GetRow(int row) =>
            (BoardState[row, 0], BoardState[row, 1], BoardState[row, 2]);

        public GameState GetBoardState()
        {

            var combinations = GetWinCombinations();

            var playerWon = combinations.Any(c => c.All(fs => fs == FieldState.Player));
            var opponentWon = combinations.Any(c => c.All(fs => fs == FieldState.Opponent));

            if (playerWon && opponentWon)
                throw new Exception($"Impossible condition of both player and oppnent winning has been met");
            if (playerWon)
                return GameState.PlayerWon;
            if (opponentWon)
                return GameState.OpponentWon;
            if (!GetPossibleMoves().Any())
                return GameState.Draw;
            return GameState.Ongoing;
        }

        private FieldState[] GetRowState(int row) =>
            new FieldState[] { BoardState[row, 0], BoardState[row, 1], BoardState[row, 2] };

        private FieldState[] GetColumnState(int col) =>
            new FieldState[] { BoardState[0, col], BoardState[1, col], BoardState[2, col] };

        private FieldState[][] GetDiagonalStates() =>
            new[] {
                new[] { BoardState[0,0], BoardState[1,1], BoardState[2,2] },
                new[] { BoardState[2,0], BoardState[1,1], BoardState[0,2] }
            };

        private FieldState[][] GetWinCombinations()
        {
            var winCons = new List<FieldState[]>();
            foreach (var i in Enumerable.Range(0, 3))
            {
                winCons.Add(GetRowState(i));
                winCons.Add(GetColumnState(i));
            }
            return winCons.Concat(GetDiagonalStates()).ToArray();
        }

    }
}