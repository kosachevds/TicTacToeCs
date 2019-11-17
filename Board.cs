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

        public bool IsFilled => this.Table.All(x => x != Mark.Empty);

        public IEnumerable<int> GetEmptyIndeces()
        {
            for (int i = 0; i < this.Table.Length; ++i)
            {
                if (this.Table[i] == Mark.Empty)
                {
                    yield return i;
                }
            }
        }

        private bool CheckWin(Mark mark)
        {
            return
                (this.Table[0] == mark && this.Table[1] == mark && this.Table[2] == mark) ||
                (this.Table[3] == mark && this.Table[4] == mark && this.Table[5] == mark) ||
                (this.Table[6] == mark && this.Table[7] == mark && this.Table[8] == mark) ||
                (this.Table[0] == mark && this.Table[3] == mark && this.Table[6] == mark) ||
                (this.Table[1] == mark && this.Table[4] == mark && this.Table[7] == mark) ||
                (this.Table[2] == mark && this.Table[5] == mark && this.Table[8] == mark) ||
                (this.Table[0] == mark && this.Table[4] == mark && this.Table[8] == mark) ||
                (this.Table[2] == mark && this.Table[4] == mark && this.Table[6] == mark);
        }

    }
}