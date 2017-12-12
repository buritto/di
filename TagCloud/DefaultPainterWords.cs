using System;
using System.Drawing;

namespace TagCloud
{
    internal class DefaultPainterWords : IWordPainter
    {
        public float maxSize { get; }
        public FontStyle fontStyle { get; }
        public FontFamily fontFamily { get; }

        public DefaultPainterWords()
        {
            maxSize = 150;
            fontFamily = FontFamily.GenericSansSerif;
            fontStyle = FontStyle.Regular;
        }

        public Color GetColorWord(string word)
        {
            return Color.Red;
        }

        public Font GetFontWord(string word, Single sizeFont)
        {
            return new Font(fontFamily, sizeFont, fontStyle);
        }

        public float GetFontSize(string word, float maxWeight, float minWeight, float weightWord)
        {
            return maxSize * (weightWord - minWeight) / (maxWeight - minWeight);
        }
    }
}