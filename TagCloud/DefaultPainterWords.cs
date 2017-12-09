using System.Drawing;

namespace TagCloud
{
    class DefaultPainterWords : IWordPainter
    {
        public Color GetColorWord(string word, Size rectangleForWord)
        {
            return Color.Black;
        }

        public Font GetFontWord(string word, Size rectangleForWord)
        {
            return  new Font(FontFamily.GenericSansSerif, 12);
        }
        
    }
}
