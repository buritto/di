using System.Drawing;

namespace TagCloud
{
    internal class DefaultWordPainter : IWordPainter
    {
        public float MaxSize { get; }
        public FontStyle FontStyle { get; }
        public FontFamily FontFamily { get; }
        public Color Color { get; }

        public DefaultWordPainter(Color color, float maxSize, FontStyle fontStyle)
        {
            MaxSize = maxSize;
            FontFamily = FontFamily.GenericSansSerif;
            FontStyle = fontStyle;
            Color = color;
        }

        public Color GetColorWord(string word)
        {
            return Color;
        }

        public Font GetFontWord(string word, float sizeFont)
        {
            return new Font(FontFamily, sizeFont, FontStyle);
        }

        public float GetFontSize(string word, float maxWeight, float minWeight, float weightWord)
        {
            var size = MaxSize * ((weightWord - minWeight) / (maxWeight - minWeight + 1));
            return size;
        }
    }
}