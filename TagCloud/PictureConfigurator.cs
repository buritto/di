namespace TagCloud
{
    class PictureConfigurator
    {
        public int Height { get; }
        public  int Width { get; }
        public IWordPainter Painter;


        public PictureConfigurator(int width, int height)
        {
            Width = width;
            Height = height;
            Painter = new DefaultPainterWords();
        }

        public PictureConfigurator SetWordPainter(IWordPainter painter)
        {
            Painter = painter;
            return this;
        }

    }
}
