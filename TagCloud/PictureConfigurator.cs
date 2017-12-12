using System.Drawing;

namespace TagCloud
{
    class PictureConfigurator
    {
        public int Height { get; }
        public  int Width { get; }
        public IWordPainter Painter;


        public PictureConfigurator(int width, int height, Color color, float maxSize = 120, FontStyle fontStyle = FontStyle.Regular)
        {
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
