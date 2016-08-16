using Windows.Foundation;

namespace BenEllis.ConnectFour.Game
{
    public static class GameUtils
    {
        public static BoardLocation GetLocation(int index, int columns, int rows)
        {
            int col = index % columns;
            int row = rows - (index / columns) - 1;
            return new BoardLocation(col, row);
        }

        public static Point GetPosition(BoardLocation location, double offsetX, double offsetY, double slotSize, double slotPadding)
        {
            double extraOffset = slotSize / 2 + slotPadding / 2;
            offsetX += extraOffset;
            offsetY += extraOffset;

            double x = offsetX + (slotSize + slotPadding) * location.Column;
            double y = offsetY + (slotSize + slotPadding) * location.Row;

            return new Point(x, y);
        }
    }
}