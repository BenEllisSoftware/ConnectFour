using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace BenEllis.ConnectFour.Shapes
{
    public class GameBoardDetailsShape : GameBoardShapeBase
    {
        protected override Geometry BuildGeometry()
        {
            const double detailsOffset = 2.5;

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
                StartPoint = new Point(detailsOffset + cornerRadius, detailsOffset),
                Segments = new PathSegmentCollection
                {
                    new LineSegment { Point = new Point(width - cornerRadius - detailsOffset, detailsOffset) },
                    new ArcSegment  { Point = new Point(width - detailsOffset, cornerRadius + detailsOffset), Size = new Size(cornerRadius, cornerRadius), SweepDirection = SweepDirection.Clockwise},
                    new LineSegment { Point = new Point(width - detailsOffset, height - detailsOffset) },
                    new LineSegment { Point = new Point(detailsOffset, height - detailsOffset) },
                    new LineSegment { Point = new Point(detailsOffset, cornerRadius + detailsOffset) },
                    new ArcSegment  { Point = new Point(cornerRadius + detailsOffset, detailsOffset), Size = new Size(cornerRadius, cornerRadius), SweepDirection = SweepDirection.Clockwise}
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

            double radius = slotSize/2 + detailsOffset;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    double x = boardPadding.Left + slotSize / 2 + slotPadding / 2 + (slotPadding + slotSize) * col;
                    double y = boardPadding.Top  + slotSize / 2 + slotPadding / 2 + (slotPadding + slotSize) * row;
                    EllipseGeometry hole = new EllipseGeometry
                    {
                        Center = new Point(x, y),
                        RadiusX = radius,
                        RadiusY = radius
                    };

                    geometry.Children.Add(hole);
                }
            }

            return geometry;

        }
    }
}