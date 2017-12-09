using System.Drawing;

namespace TagCloud
{
    class PictureConfigurator
    {
        public int Height { get; }
        public  int Width { get; }
        public IWordPainter Painter;
        public Color Background { get;}


        public PictureConfigurator(int width, int height, Color background, int width1)
        {
            Width = width;
            Height = height;
            Background = background;
            this.Width = width1;
            Painter = new DefaultPainterWords();
        }

        public PictureConfigurator SetWordPainter(IWordPainter painer)
        {
            Painter = painer;
            return this;
        }

    }
}
