using System;

namespace TicTacToe
{
    public class ConsoleClient
    {
        private Mark _humanMark;
        private Mark _aiMark;

        public ConsoleClient(Mark humanMark, Mark aiMark)
        {
            this._humanMark = humanMark;
            this._aiMark = aiMark;
        }

        public void Run()
        {
            var board = new Board();
            var aiPlayer = new AiPlayer(this._aiMark);
            Console.Clear();
            var winner = RunUntilWin(board, aiPlayer);
            PrintEndMessage(board, winner);
        }

        private void PrintEndMessage(Board board, Mark winner)
        {
            const string endMessageFormat = "{0} won!";
            const string ai = "AI";
            const string human = "Human";
            const string noOne = "No one";

            var strWinner = String.Empty;
            if (winner == this._aiMark)
            {
                strWinner = ai;
            }
            else if (winner == this._humanMark)
            {
                strWinner = human;
            }
            else
            {
                strWinner = noOne;
            }
            Console.SetCursorPosition(0, board.Width + 1);
            Console.WriteLine(endMessageFormat, strWinner);
        }

        private Mark RunUntilWin(Board board, AiPlayer aiPlayer)
        {
            var continueGame = true;
            Mark? winner = null;
            while (continueGame)
            {
                ReprintBoard(board);
                winner = board.GetWinner();
                if (winner != null)
                {
                    break;
                }
                DoHumanMove(board);
                ReprintBoard(board);
                continueGame = aiPlayer.TryMove(board);
            }
            return (Mark)(winner ?? Mark.Empty);
        }

        private static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Table.Length; ++i)
            {
                Console.Write(GetMarkChar(board.Table[i]));
                if ((i + 1) % board.Width == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        private static char GetMarkChar(Mark mark)
        {
            switch (mark)
            {
            case Mark.Empty:
                return '_';
            case Mark.Cross:
                return 'x';
            case Mark.Zero:
                return 'o';
            }
            throw new ArgumentException();
        }

        private void DoHumanMove(Board board)
        {
            var index = GetHumanPlayerMove(board);
            // TODO: check index's cell for Empty
            board.Table[index] = this._humanMark;
        }

        private int GetHumanPlayerMove(Board board)
        {
            Console.SetCursorPosition(0, 0);
            while (true)
            {
                var key = Console.ReadKey();
                HandleArrowKey(key.Key);
                ReprintBoard(board);
                if (key.Key != ConsoleKey.Spacebar)
                    continue;
                Console.CursorLeft -= 1;
                if (Console.CursorTop >= board.Width)
                    continue;
                if (Console.CursorLeft >= board.Width)
                    continue;
                return Console.CursorTop * board.Width + Console.CursorLeft;
            }
        }

        private static void HandleArrowKey(ConsoleKey key)
        {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    top += 1;
                    break;
                case ConsoleKey.UpArrow:
                    top -= 1;
                    break;
                case ConsoleKey.LeftArrow:
                    left -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    left += 1;
                    break;
                default:
                    return;
            }
            left -= 1;
            if (left < 0)
            {
                left = 0;
            }
            if (top < 0)
            {
                top = 0;
            }
            Console.SetCursorPosition(left, top);
        }

        private static void ReprintBoard(Board board)
        {
            var old = new { Top = Console.CursorTop, Left = Console.CursorLeft };
            Console.SetCursorPosition(0, 0);
            PrintBoard(board);
            Console.SetCursorPosition(old.Left, old.Top);
        }
    }
}