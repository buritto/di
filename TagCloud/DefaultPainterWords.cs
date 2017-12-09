using System.Drawing;

namespace TagCloud
{
    internal class DefaultPainterWords : IWordPainter
    {
        public Color GetColorWord(string word, Size rectangleForWord)
        {
            return Color.Red;
        }

        public Font GetFontWord(string word, Size rectangleForWord)
        {
            return new Font(FontFamily.GenericSansSerif, rectangleForWord.Height / word.Length + 1);
        }
    }
}