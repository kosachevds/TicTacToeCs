namespace TicTacToe
{
    public class Solution
    {
        public Solution(int score, int index)
        {
            this.Score = score;
            this.Index = index;
        }

        public Solution(int score)
            : this(score, -1)
        {
        }

        public int Score { get; }

        public int Index { get;  set; }
    }
}