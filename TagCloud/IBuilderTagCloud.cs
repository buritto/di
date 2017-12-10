using System.Drawing;

namespace TagCloud
{
    interface IBuilderTagCloud
    {
        Point GetLocationNextRectangle(Size rectangleSize);

    }
}
