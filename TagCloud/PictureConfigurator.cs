using System.Drawing;
using System.Drawing.Imaging;

namespace TagCloud
{
    class PictureConfigurator
    {
        public int Height { get; }
        public  int Width { get; }
        public IWordPainter Painter;
        public Color Background { get;}
        public ImageFormat Format;


        public PictureConfigurator(int width, int height, Color background, int width1, ImageFormat format)
        {
            Width = width;
            Height = height;
            Background = background;
            this.Width = width1;
            Format = format;
            Painter = new DefaultPainterWords();
        }

        public PictureConfigurator SetWordPainter(IWordPainter painter)
        {
            Painter = painter;
            return this;
        }

    }
}
