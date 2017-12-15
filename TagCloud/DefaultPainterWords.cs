using System;
using System.Drawing;

namespace TagCloud
{
    internal class DefaultPainterWords : IWordPainter
    {
        public float MaxSize { get; }
        public FontStyle FontStyle { get; }
        public FontFamily FontFamily { get; }
        public Color Color { get; }

        public DefaultPainterWords(Color color, float maxSize, FontStyle fontStyle)
        {
            this.MaxSize = maxSize;
            FontFamily = FontFamily.GenericSansSerif;
            this.FontStyle = fontStyle;
            this.Color = color;
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