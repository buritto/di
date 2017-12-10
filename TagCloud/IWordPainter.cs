using System.Drawing;

namespace TagCloud
{
    interface IWordPainter
    {
        Color GetColorWord(string word);
        Font GetFontWord(string word);
    }
}
