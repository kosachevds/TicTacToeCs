namespace TicTacToe
{
    public enum Mark
    {
        Cross, Zero, Empty
    }

    public static class MarkExtension
    {
        public static Mark GetOpponentMark(this Mark mark)
        {
            if (mark == Mark.Cross)
            {
                return Mark.Zero;
            }
            if (mark == Mark.Zero)
            {
                return Mark.Cross;
            }
            return Mark.Empty;
        }
    }
}