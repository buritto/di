using System;
using System.Drawing;

namespace TagCloud
{
    class PictureConfigurator : IPainter
    {
        public int Height { get; private set; }
        public  int Width { get; private set; }
        public IWordPainter Painter { get; private set; }


        private void CheckCorrectArgumentConstructor(int width, int height, Color color)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width or height less zero");
            }
            if (color == null)
            {
                throw new ArgumentException("Color is null");
            }
        }

        public PictureConfigurator(int width, int height, Color color, float maxSize = 120, FontStyle fontStyle = FontStyle.Regular)
        {
            CheckCorrectArgumentConstructor(width, height,color);
            Width = width;
            Height = height;
            Painter = new DefaultPainterWords(color, maxSize, fontStyle);
        }

        public PictureConfigurator SetWordPainter(IWordPainter painter)
        {
            Painter = painter;
            return this;
        }

    }
}
