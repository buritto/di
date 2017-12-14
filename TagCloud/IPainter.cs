namespace TagCloud
{
    interface IPainter
    {
        IWordPainter Painter { get;}
        int Height { get;}
        int Width { get;}
        PictureConfigurator SetWordPainter(IWordPainter painter);
    }
}
