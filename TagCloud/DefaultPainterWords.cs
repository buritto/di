using System;
using System.Drawing;

namespace TagCloud
{
    internal class DefaultPainterWords : IWordPainter
    {
        public float maxSize { get; }
        public FontStyle fontStyle { get; }
        public FontFamily fontFamily { get; }
        public Color color { get; }

        public DefaultPainterWords(Color color, float maxSize, FontStyle fontStyle)
        {
            this.maxSize = maxSize;
            fontFamily = FontFamily.GenericSansSerif;
            this.fontStyle = fontStyle;
            this.color = color;
        }

        public Color GetColorWord(string word)
        {
            return color;
        }

        public Font GetFontWord(string word, Single sizeFont)
        {
            return new Font(fontFamily, sizeFont, fontStyle);
        }

        public float GetFontSize(string word, float maxWeight, float minWeight, float weightWord)
        {
            var size = maxSize * (weightWord - minWeight) / (maxWeight - minWeight);
            return size;
        }
    }
}