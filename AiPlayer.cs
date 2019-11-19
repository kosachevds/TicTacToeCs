using System.Linq;

namespace TicTacToe
{
    public class AiPlayer
    {
        private const int AiWinScore = 1;
        private const int AiLoseScore = -1;
        private const int NoOneWin = 0;

        private readonly Mark _mark;
        private readonly Mark _opponent;

        public AiPlayer(Mark mark)
        {
            this._mark = mark;
            this._opponent = mark.GetOpponentMark();
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