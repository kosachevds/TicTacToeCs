namespace TicTacToe
{
    public class AiPlayer
    {
        private readonly Mark _mark;

        public AiPlayer(Mark mark)
        {
            this._mark = mark;
        }

        public int DoStep(Board board)
        {
            return FindSolution(board, this._mark).Index;
        }

        private Solution FindSolution(Board board, Mark mark)
        {

        }
    }
}