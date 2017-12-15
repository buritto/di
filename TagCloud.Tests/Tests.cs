using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TagCloud.Tests
{
    [TestFixture]
    class TestTagCloud
    {

        //[TestCase(-100, 100)]
        //[TestCase(100, -100)]
        //public void TestPictureConfigWithIncorrectArgumentsWindow(int width, int height)
        //{
        //    Color color = Color.Aqua;
        //    var fakePictureConfig = new Mock<PictureConfigurator>(width, height, color, 120, FontStyle.Regular);

        //}

        private Mock<IFormatReader> reader;
        private Mock<IWordFilter> wordFilter;
        private Mock<IPainter> painter;
        private Mock<ITagCloudBuilder> tagCloudBuilder;
        private Mock<IWordPainter> wordPainter;
        [SetUp]
        public void SetUp()
        {
            reader = new Mock<IFormatReader>();
            reader.Setup(formatReader => formatReader.GetFileData(It.IsAny<string>())).Returns(
                new List<Word>()
                {
                    new Word("word1", 1),
                    new Word("Word2", 2),
                    new Word("Word3", 3)
                });
            wordFilter = new Mock<IWordFilter>();
            wordFilter.Setup(filter => filter.IsWordValid(It.IsAny<string>())).Returns(true);
            painter = new Mock<IPainter>();
            painter.Setup(p => p.Height).Returns(100);
            painter.Setup(p => p.Width).Returns(100);
            tagCloudBuilder = new Mock<ITagCloudBuilder>();
            wordPainter = new Mock<IWordPainter>();
            painter.Setup(p => p.Painter).Returns(wordPainter.Object);
            wordPainter.Setup(p => p.GetFontWord(It.IsAny<string>(), It.IsAny<float>()))
                .Returns(new Font(FontFamily.GenericSansSerif, 100, FontStyle.Regular));
            wordPainter.Setup(p => p.GetColorWord(It.IsAny<string>())).Returns(Color.Red);

        }

        [TestCase(100, 100, 100, "someWord")]
        [TestCase(12, 100, 100, "someWord")]
        [TestCase(100, 23, 100, "someWord")]
        [TestCase(100, 22, 23, "someWord")]
        public void TestGetFont(float maxWeight, float minWeight, float weightWord, string word)
        {
            var exprected = new Font(FontFamily.GenericSansSerif, 100, FontStyle.Regular);
            wordPainter.Setup(p => p.GetFontWord(It.IsAny<string>(), It.IsAny<float>()))
                .Returns(exprected);
            wordPainter.Setup(p =>
                    p.GetFontSize(word, maxWeight, minWeight, weightWord))
                .Returns(100);
            var actual = TagCloud.GetFont(wordPainter.Object, maxWeight, minWeight, weightWord, word);
            actual.Should().Be(exprected);
        }

        [Test]
        public void CallGetFontForEachDifferentWord()
        {
            var tagCloud = new TagCloud(reader.Object, wordFilter.Object, painter.Object, tagCloudBuilder.Object);
            tagCloud.PaintTagCloud("testTextFile.txt", "testPicture.png");
            wordPainter.Verify(wp => wp.GetFontWord(It.IsAny<string>(), It.IsAny<float>()), Times.Exactly(3));
        }

        [Test]
        public void CallGetColorForEachDifferentWord()
        {
            var tagCloud = new TagCloud(reader.Object, wordFilter.Object, painter.Object, tagCloudBuilder.Object);
            tagCloud.PaintTagCloud("testTextFile.txt", "testPicture.png");
            wordPainter.Verify(wp => wp.GetColorWord(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
