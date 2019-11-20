using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ConsoleClient(Mark.Cross, Mark.Zero);
            client.Run();
        }
    }
}
