using System.Drawing;

namespace TagCloud
{
    public interface ITagCloudBuilder
    {
        Point GetLocationNextRectangle(Size rectangleSize);
    }
}
