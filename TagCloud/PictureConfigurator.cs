using System;
using System.Drawing;
using JetBrains.Annotations;

namespace TagCloud
{
    public class PictureConfigurator : IPainter
    {
        public int Height { get; }
        public int Width { get; }
        public IWordPainter Painter { get; private set; }

        public PictureConfigurator(int width, int height, Color color, float maxSize = 120, FontStyle fontStyle = FontStyle.Regular)
        {
            CheckCorrectArgumentConstructor(width, height,color);
            Width = width;
            Height = height;
            Painter = new DefaultWordPainter(color, maxSize, fontStyle);
        }

        [AssertionMethod]
        private static void CheckCorrectArgumentConstructor(int width, int height, Color color)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Width or height less zero");
            if (color == null)
                throw new ArgumentException("Color is null");
        }

        public PictureConfigurator SetWordPainter(IWordPainter painter)
        {
            Painter = painter;
            return this;
        }
    }
}
