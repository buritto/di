using System.Drawing;

namespace TagCloud
{
    public interface IWordPainter
    {
        float MaxSize { get;}
        FontStyle FontStyle { get; }
        FontFamily FontFamily { get; }
        Color Color { get; }
        Color GetColorWord(string word);
        Font GetFontWord(string word, float sizeFont);
        float GetFontSize(string word, float maxWeight, float minWeight, float weightWord);
    }
}
