namespace BenEllis.ConnectFour.Game
{
    public struct BoardLocation
    {
        public int Column { get; set; }

        public int Row { get; set; }

        public BoardLocation(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}