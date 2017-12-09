using System.Drawing;

namespace TagCloud
{
    interface IWordPainter
    {
        Color GetColorWord(string word, Size rectangleForWord);
        Font GetFontWord(string word, Size rectangleForWord);
    }
}
