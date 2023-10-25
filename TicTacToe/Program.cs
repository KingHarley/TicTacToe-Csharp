namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var board = Board.CreateNewBoard();
            Render.RenderBoard(board);
            Render.RenderSpace();
            var gameState = board.GetBoardState();

            while(gameState == GameState.Ongoing)
            {
                board = Opponent.MakeRandomMove(board);
                gameState = board.GetBoardState();
                Render.RenderBoard(board);
                Render.RenderSpace();

                if (gameState != GameState.Ongoing)
                    break;

                var possibleMoves = board.GetPossibleMoves();
                if (!possibleMoves.Any())
                    throw new Exception($"There are no possible moves for the player and the game should have already ended");
                var playerMove = Input.GetInputField(possibleMoves);
                board = board.MakeMove(playerMove, FieldState.Player);
                Render.RenderBoard(board);
                Render.RenderSpace();
                gameState = board.GetBoardState();

            }
            FinishGame(gameState);
        }

        static void FinishGame(GameState gameState)
        {
#pragma warning disable 8524
            var finalWords = gameState switch
            {
                GameState.PlayerWon => "Congrats you've won!",
                GameState.OpponentWon => "Opponent has won!",
                GameState.Draw => "The game is a draw!",
                GameState.Ongoing => throw new Exception($"The game is {gameState} and should not have ended")
            } ;
#pragma warning restore 8524

            Console.WriteLine(finalWords);
        }

    }
}