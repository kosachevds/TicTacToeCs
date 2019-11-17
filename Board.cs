namespace TicTacToe
{
    public class Board
    {
        private const int BoardWidth = 3;

        public Board()
        {
            this.Marks = new Mark[BoardWidth * BoardWidth];
            for (var i = 0; i < this.Marks.Length; ++i)
            {
                this.Marks[i] = Mark.Empty;
            }
        }

        public Mark[] Marks { get; }
    }
}