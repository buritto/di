using System.Drawing;
using Moq;
using NUnit.Framework;

namespace TagCloud
{
    [TestFixture]
    class TestTagCloud
    {
        [TestCase("word1 word2 word1 word2")]
        public void TestCorrectUsingWordPainter_Get(string text)
        {
            var FakeWordPainter = new Mock<IWordPainter>();
            FakeWordPainter.Verify(painter => painter.GetFontSize(It.IsAny<string>()
                ,It.IsAny<float>(), It.IsAny<float>(), It.IsAny<float>()), Times.AtLeast(2));
            
        }

    }
}
