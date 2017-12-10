using System.Drawing;

namespace TagCloud
{
    internal class DefaultPainterWords : IWordPainter
    {
        public Color GetColorWord(string word)
        {
            return Color.Red;
        }

        public Font GetFontWord(string word)
        {
            return new Font(FontFamily.GenericSansSerif, 24);
        }
    }
}