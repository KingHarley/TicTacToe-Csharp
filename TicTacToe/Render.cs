using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal static class Render
    {
        public static void RenderBoard(Board board)
        {
            Console.WriteLine("   A B C");
            Console.WriteLine(BarrierRow);
            Console.WriteLine(RenderRow(board, 0));
            Console.WriteLine(BarrierRow);
            Console.WriteLine(RenderRow(board, 1));
            Console.WriteLine(BarrierRow);
            Console.WriteLine(RenderRow(board, 2));
            Console.WriteLine(BarrierRow);
        }

        private static string GetMarker(FieldState state) =>
#pragma warning disable 8524
            state switch
            {
                FieldState.Empty => " ",
                FieldState.Player => "X",
                FieldState.Opponent => "O"
            };
#pragma warning restore 8524

        private const string BarrierRow = "  -------";

        private static string RenderRow(Board board, int row)
        {
            var rowVals = board.GetRow(row);
            return $"{row + 1} |{GetMarker(rowVals.First)}|{GetMarker(rowVals.Second)}|{GetMarker(rowVals.Third)}|";
        }

        public static void RenderSpace()
        {
            foreach(var x in Enumerable.Range(0, 3))
                Console.WriteLine();
        }
    }
}
