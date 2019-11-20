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
            while (true)
            {
                Console.Clear();
                // TODO: reset cursor instead of clear
                PrintBoard(board);
                if (board.GetWinner() != null)
                    break;
                DoHumanStep(board);
                DoAiStep(board, aiPlayer);
            }
        }

        private void PrintBoard(Board board)
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

        private char GetMarkChar(Mark mark)
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
                if (key.Key != ConsoleKey.Enter)
                    continue;
                var index = Console.CursorTop * Board.TableWidth + Console.CursorLeft;
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
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    break;
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    break;
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    break;
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    break;
                default:
                    break;
            }
        }

        private void DoAiStep(Board board, AiPlayer aiPlayer)
        {
            var index = aiPlayer.DoStep(board);
            board.Table[index] = this._aiMark;
        }
    }
}