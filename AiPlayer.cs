using System;
using System.Collections.Generic;
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
            var winner = board.GetWinner();
            if (winner == this._mark)
            {
                return new Solution(AiWinScore);
            }
            if (winner == this._opponent)
            {
                return new Solution(AiLoseScore);
            }
            var emptyCells = board.GetEmptyIndeces();
            if (!emptyCells.Any())
            {
                return new Solution(NoOneWin);
            }

            var nextBoard = board.Copy();
            var solutions = new List<Solution>();
            foreach (var index in emptyCells)
            {
                nextBoard.Table[index] = mark;
                var possibleSolution = FindSolution(board, mark.GetOpponentMark());
                possibleSolution.Index = index;
                solutions.Add(possibleSolution);
                nextBoard.Table[index] = Mark.Empty;
            }

            if (mark == this._mark) {
                return Utils.FindWithMax(solutions, x => x.Score);
            }
            return Utils.FindWithMin(solutions, x => x.Score);
        }
    }
}