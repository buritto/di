using System.Drawing;

namespace TagCloud
{
    class DefaultPainterWords : IWordPainter
    {
        public Color PaintWord(string word, Size rectangleFirWord)
        {
            return Color.Black;
        }
    }
}
