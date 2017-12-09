using System.Drawing;
using System.Drawing.Imaging;

namespace TagCloud
{
    class PictureConfigurator
    {
        public int Height { get; }
        public  int Width { get; }
        public IWordPainter Painter;
        public ImageFormat Format;
        public Font TextFont { get; }


        public PictureConfigurator(int width, int height, int width1, ImageFormat format, Font font)
        {
            Width = width;
            Height = height;
            this.Width = width1;
            Format = format;
            Painter = new DefaultPainterWords();
            TextFont = font;
        }

        public PictureConfigurator SetWordPainter(IWordPainter painter)
        {
            Painter = painter;
            return this;
        }

    }
}
