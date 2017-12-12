using System;
using System.Drawing;

namespace TagCloud
{
    interface IWordPainter
    {
        Single maxSize { get;}
        FontStyle fontStyle { get; }
        FontFamily fontFamily { get; }
        Color GetColorWord(string word);
        Font GetFontWord(string word, Single sizeFont);
        Single GetFontSize(string word, Single maxWeight, Single minWeight, Single weightWord);
    }
}
