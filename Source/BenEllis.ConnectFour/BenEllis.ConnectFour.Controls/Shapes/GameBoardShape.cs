using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace BenEllis.ConnectFour.Shapes
{
    public class GameBoardShape : GameBoardShapeBase
    {
        protected override Geometry BuildGeometry()
        {
            double slotSize = SlotSize;
            double slotPadding = SlotPadding;
            double cornerRadius = BoardCornerRadius;

            Thickness boardPadding = BoardPadding;

            int rows = Rows;
            int columns = Columns;

            double width  = (slotSize + slotPadding) * columns + boardPadding.Left + boardPadding.Right;
            double height = (slotSize + slotPadding) * rows    + boardPadding.Top + boardPadding.Bottom;

            var boardFigure = new PathFigure
            {
                StartPoint = new Point(cornerRadius, 0),
                Segments = new PathSegmentCollection
                {
                    new LineSegment { Point = new Point(width - cornerRadius, 0) },
                    new ArcSegment  { Point = new Point(width, cornerRadius), Size = new Size(cornerRadius, cornerRadius), SweepDirection = SweepDirection.Clockwise},
                    new LineSegment { Point = new Point(width, height) },
                    new LineSegment { Point = new Point(0, height) },
                    new LineSegment { Point = new Point(0, cornerRadius) },
                    new ArcSegment  { Point = new Point(cornerRadius, 0), Size = new Size(cornerRadius, cornerRadius), SweepDirection = SweepDirection.Clockwise}
                }
            };

            var boardGeometry = new PathGeometry
            {
                Figures = new PathFigureCollection
                {
                    boardFigure
                }
            };

            var geometry = new GeometryGroup
            {
                FillRule = FillRule.EvenOdd,
                Children = new GeometryCollection
                {
                    boardGeometry
                }
            };

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    double x = boardPadding.Left + slotSize / 2 + slotPadding / 2 + (slotPadding + slotSize) * col;
                    double y = boardPadding.Top  + slotSize / 2 + slotPadding / 2 + (slotPadding + slotSize) * row;
                    EllipseGeometry hole = new EllipseGeometry
                    {
                        Center = new Point(x, y),
                        RadiusX = slotSize / 2,
                        RadiusY = slotSize / 2
                    };

                    geometry.Children.Add(hole);
                }
            }

            return geometry;
        }
    }
}