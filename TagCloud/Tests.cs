using System;
using System.Collections.Generic;
using System.Drawing;
using Moq;
using NUnit.Framework;

namespace TagCloud
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
