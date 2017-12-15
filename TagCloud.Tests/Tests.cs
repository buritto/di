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
            wordFilter = new Mock<IWordFilter>();
            painter = new Mock<IPainter>();
            tagCloudBuilder = new Mock<ITagCloudBuilder>();
            wordPainter = new Mock<IWordPainter>();
           
        }

        [TestCase(100, 100, 100, "someWord")]
        public void TestGetFontForWordEqualWeight(float maxWeight, float minWeight, float weightWord, string word)
        {
            var exprected = new Font(FontFamily.GenericSansSerif, 100, FontStyle.Regular);
            wordPainter.Setup(p => p.GetFontWord(It.IsAny<string>(), It.IsAny<float>()))
                .Returns(exprected);
            wordPainter.Setup(p =>
                    p.GetFontSize(word, maxWeight, minWeight, weightWord))
                .Returns(100);
            var tagCloud = new TagCloud(reader.Object, wordFilter.Object, painter.Object, tagCloudBuilder.Object);
            var actual = TagCloud.GetFont(wordPainter.Object, maxWeight, minWeight, weightWord, word);
            actual.Should().Be(exprected);

        }

        [TestCase("word1 word2 word1 word2")]
        public void TestCorrectUsingWordPainter_GetFileData(string text)
        {
            var fakeWordPainter = new Mock<IWordPainter>();
            fakeWordPainter.Verify(painter => painter.GetFontSize(It.IsAny<string>()
                ,It.IsAny<float>(), It.IsAny<float>(), It.IsAny<float>()), Times.AtLeast(2));
            var fakeReader = new Mock<IFormatReader>();
            //fakeReader.Setup(reader => reader.GetFileData(It.IsAny<string>())).Returns(
            //    new List<Tuple<string, int>>{
            //    new Tuple<string, int>("word1", 2),
            //    new Tuple<string, int>("word2", 2)});
        }

    }
}
