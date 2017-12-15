namespace TagCloud
{
    /// <summary>
    /// Responsible for the size of the window.
    /// </summary>
    public interface IWindow
    {
        int Height { get; }
        int Width { get; }
    }

    public interface IPainter : IWindow
    {
        /// <summary>
        /// Responsible for the design of objects in the cloud.S
        /// </summary>
        IWordPainter Painter { get;}
        PictureConfigurator SetWordPainter(IWordPainter painter);
    }
}
