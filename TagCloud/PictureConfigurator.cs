using System.Drawing;
using JetBrains.Annotations;

namespace TagCloud
{
    public class PictureConfigurator : IPainter
    {
        public Result<int> Height { get; }
        public Result<int> Width { get; }
        public IWordPainter Painter { get; private set; }

        public PictureConfigurator(int width, int height, Color color, 
                                    float maxSize = 120, FontStyle fontStyle = FontStyle.Regular)
        {
            Width = width.AsResult().Then(CheckCorrectArgumentWindowsSize);
            Height = height.AsResult().Then(CheckCorrectArgumentWindowsSize);
            Painter = new DefaultWordPainter(color.AsResult().Then(CheckColorIsEmpty).TryGetValue(), maxSize, fontStyle);
        }

        [AssertionMethod]
        private static Result<int> CheckCorrectArgumentWindowsSize(int side)
        {
            return side < 1 ? Result.Fail<int>("Lenght side of window be less one") : side.AsResult();
        }

        [AssertionMethod]
        private static Result<Color> CheckColorIsEmpty(Color color)
        {
            return color.IsEmpty ? Result.Fail<Color>("Color is Empty") : color.AsResult();
        }
        public PictureConfigurator SetWordPainter(IWordPainter painter)
        {
            Painter = painter;
            return this;
        }
    }
}
