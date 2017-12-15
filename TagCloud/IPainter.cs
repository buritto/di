namespace TagCloud
{
    public interface IWindow
    {
        int Height { get; }
        int Width { get; }
    }

    public interface IPainter : IWindow
    {
        IWordPainter Painter { get;}
        PictureConfigurator SetWordPainter(IWordPainter painter);
    }
}
