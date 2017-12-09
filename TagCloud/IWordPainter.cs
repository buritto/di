using System.Drawing;

namespace TagCloud
{
    interface IWordPainter
    {
        Color PaintWord(string word, Size rectangleFirWord);
    }
}
