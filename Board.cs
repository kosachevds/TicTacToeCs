using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public const int TableWidth = 3;

        private Board(Mark[] table)
        {
            this.Table = (Mark[])table.Clone();
        }

        public Board()
        {
            this.Table = new Mark[TableWidth * TableWidth];
            Array.Fill(this.Table, Mark.Empty);
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

        public Mark? GetWinner()
        {
            if (CheckWin(Mark.Cross))
            {
                return Mark.Cross;
            }
            if (CheckWin(Mark.Zero))
            {
                return Mark.Zero;
            }
            return null;
        }

        public void CopyTo(Board other)
        {
            Array.Copy(this.Table, other.Table, this.Table.Length);
        }

        public Board Copy()
        {
            var other = new Board();
            this.CopyTo(other);
            return other;
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