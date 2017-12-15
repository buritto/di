using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagCloud
{
    public class SpiralBuilder: ITagCloudBuilder
    {
        private readonly List<Rectangle> builtRectangles;
        private List<Point> spiralPoints;
        private Rectangle window;

        private void PutPointsOnSpiral(Point centerWindow)
        {
            spiralPoints = new List<Point>();
            var step = 0.0;
            while (true)
            {
                var x = (int)(step * Math.Cos(step) + centerWindow.X);
                var y = (int)(step * Math.Sin(step) + centerWindow.Y);

                if (SpiralGoingOutWindow(x, y))
                {
                    spiralPoints = spiralPoints.Distinct().ToList();
                    break;
                }
                step += 0.1;
                spiralPoints.Add(new Point(x, y));
            }
        }

        private bool SpiralGoingOutWindow(int x, int y)
        {
            return x < 0 && y < 0;
        }

        public SpiralBuilder(Point centerWindow, int widthWindow, int heightWindow)
        {
            builtRectangles = new List<Rectangle>();
            PutPointsOnSpiral(centerWindow);
            window = new Rectangle(new Point(0, 0), new Size(widthWindow, heightWindow));
        }


        public Point GetLocationNextRectangle(Size rectangleSize)
        {

            foreach (var spiralPoint in spiralPoints)
            {
                var location = CalculateLocationRectangle(rectangleSize, spiralPoint);
                var rectangle = new Rectangle(location, rectangleSize);
                if (IsCorrectLocation(rectangle))
                {
                    builtRectangles.Add(rectangle);
                    return rectangle.Location;
                }
            }
            throw new Exception("Cloud is full");
        }


        private Point CalculateLocationRectangle(Size rectangleSize, Point spiralPoint)
        {
            return new Point()
            {
                X = spiralPoint.X - rectangleSize.Width / 2,
                Y = spiralPoint.Y - rectangleSize.Height / 2
            };
        }

        private bool IsCorrectLocation(Rectangle rectangle)
        {
            var notIntersection = !builtRectangles.Any(rec => rec.IntersectsWith(rectangle));
            var outside = rectangle.X >= 0 && rectangle.Right <= window.Width
                          && rectangle.Y >= 0 && rectangle.Bottom <= window.Height;
            return notIntersection && outside;
        }

    }
}
