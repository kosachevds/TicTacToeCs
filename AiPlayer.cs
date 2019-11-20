using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class AiPlayer
    {
        private static readonly Random _random = new Random();
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

        public int GetMoveIndex(Board board)
        {
            return FindSolution(board, this._mark).Index;
        }

        public bool TryMove(Board board)
        {
            var index = GetMoveIndex(board);
            if (index < 0)
            {
                return false;
            }
            board.Table[index] = this._mark;
            return true;
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
            var emptyCells = board.GetEmptyIndeces().ToList();
            if (!emptyCells.Any())
            {
                return new Solution(NoOneWin);
            }
            if (emptyCells.Count == board.CellCount)
            {
                return new Solution(0, emptyCells[_random.Next(emptyCells.Count)]);
            }

            var nextBoard = board.Copy();
            var solutions = new List<Solution>();
            foreach (var index in emptyCells)
            {
                nextBoard.Table[index] = mark;
                var possibleSolution = FindSolution(nextBoard, mark.GetOpponentMark());
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