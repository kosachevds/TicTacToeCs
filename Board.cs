using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private const int TableWidth = 3;

        public Board()
        {
            this.Table = new Mark[TableWidth * TableWidth];
            for (var i = 0; i < this.Table.Length; ++i)
            {
                this.Table[i] = Mark.Empty;
            }
        }

        public Mark[] Table { get; }
    }
}