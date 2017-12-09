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


        public PictureConfigurator(int width, int height, ImageFormat format)
        {
            Width = width;
            Height = height;
            this.Width = width;
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
