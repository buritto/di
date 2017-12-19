using System.Drawing;

namespace TagCloud
{
    /// <summary>
    /// Responsible for building a tag cloud according to a given algorithm
    /// </summary>
    public interface ITagCloudBuilder
    {
        Result<Point> GetLocationNextRectangle(Size rectangleSize);
    }
}
