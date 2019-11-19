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
        private void DoHumanStep(Board board)
        {
            var index = GetHumanPlayerStep(board);
            board.Table[index] = this._humanMark;
        }

        private int GetHumanPlayerStep(Board board)
        {
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key != ConsoleKey.Enter)
                    continue;
                var index = Console.CursorTop * Board.TableWidth + Console.CursorLeft;
                if (index < board.Table.Length)
                {
                    return index;
                }
            }
        }

        private void DoAiStep(Board board, AiPlayer aiPlayer)
        {
            var index = aiPlayer.DoStep(board);
            board.Table[index] = this._aiMark;
        }
    }
}