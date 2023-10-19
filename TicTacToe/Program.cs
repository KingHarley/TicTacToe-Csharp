namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var board = Board.CreateNewBoard();
            var newBoard = board.MakeRandomMove(ActivePlayer.Player);

            while(true)
            {
                newBoard = newBoard.MakeRandomMove(ActivePlayer.Player);
            }
        }
    }
}