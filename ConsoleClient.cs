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
            while (true)
            {
                ReprintBoard(board);
                if (board.GetWinner() != null)
                    break;
                DoHumanStep(board);
                ReprintBoard(board);
                DoAiStep(board, aiPlayer);
            }
        }

        private static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Table.Length; ++i)
            {
                Console.Write(GetMarkChar(board.Table[i]));
                if ((i + 1) % Board.TableWidth == 0)
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

        private void DoHumanStep(Board board)
        {
            var index = GetHumanPlayerStep(board);
            // TODO: check index's cell for Empty
            board.Table[index] = this._humanMark;
        }

        private int GetHumanPlayerStep(Board board)
        {
            Console.SetCursorPosition(0, 0);
            while (true)
            {
                var key = Console.ReadKey();
                HandleArrowKey(key.Key);
                if (key.Key != ConsoleKey.Spacebar)
                    continue;
                var index = Console.CursorTop * Board.TableWidth + (Console.CursorLeft - 1);
                if (index < board.Table.Length)
                {
                    return index;
                }
            }
        }

        private static void HandleArrowKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    Console.CursorTop = Console.CursorTop + 1;
                    Console.CursorLeft = Console.CursorLeft - 1;
                    break;
                case ConsoleKey.UpArrow:
                    Console.CursorTop = Console.CursorTop - 1;
                    Console.CursorLeft = Console.CursorLeft - 1;
                    break;
                case ConsoleKey.LeftArrow:
                    Console.CursorLeft = Console.CursorLeft - 2;
                    break;
                case ConsoleKey.RightArrow:
                    Console.CursorLeft = Console.CursorLeft + 1;
                    Console.CursorLeft = Console.CursorLeft - 1;
                    break;
                default:
                    break;
            }
        }

        private static void ReprintBoard(Board board)
        {
            var old = new { Top = Console.CursorTop, Left = Console.CursorLeft };
            Console.SetCursorPosition(0, 0);
            PrintBoard(board);
            Console.SetCursorPosition(old.Left, old.Top);
        }

        private void DoAiStep(Board board, AiPlayer aiPlayer)
        {
            var index = aiPlayer.DoStep(board);
            if (index >= 0)
            {
                board.Table[index] = this._aiMark;
            }
        }
    }
}