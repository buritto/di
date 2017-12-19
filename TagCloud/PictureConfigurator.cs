using System.Drawing;
using JetBrains.Annotations;

namespace TagCloud
{
    public class PictureConfigurator : IPainter
    {
        public Result<int> Height { get; }
        public Result<int> Width { get; }
        public IWordPainter Painter { get; private set; }

        public PictureConfigurator(Result<int> width, Result<int> height, Result<Color> color, 
                                    float maxSize = 120, FontStyle fontStyle = FontStyle.Regular)
        {
            Width = width.Then(CheckCorrectArgumentWindowsSize);
            Height = height.Then(CheckCorrectArgumentWindowsSize);
            Painter = new DefaultWordPainter(color.Then(CheckColorIsEmpty).TryGetValue(), maxSize, fontStyle);
        }

        [AssertionMethod]
        private static Result<int> CheckCorrectArgumentWindowsSize(int side)
        {
            return side < 1 ? Result.Fail<int>("side less one") : side.AsResult();
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
