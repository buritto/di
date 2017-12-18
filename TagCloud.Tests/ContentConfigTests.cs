using System.Collections.Generic;
using NUnit.Framework;

namespace TagCloud.Tests
{
    [TestFixture]
    class ContentConfigTests
    {
        private string[] text;
        [SetUp]
        public void SetUp()
        {
            text = new[] { "word1", "word2", "word3", "word4" };
        }

        private List<string> GetCorrectWords(ContentConfigurator config)
        {
            var correcWord = new List<string>();
            foreach(var word in text)
            {
                if (config.IsWordValid(word))
                    correcWord.Add(word);
            }
            return correcWord;
        }

        [Test]
        public void ExcludeWordInConfigWithConstructor()
        {
            var excludeWord = new HashSet<string> {"word1", "word2"};
            var config = new ContentConfigurator(excludeWord);
            var exprectd = new List<string> {"word3", "word4"};
            Assert.AreEqual(exprectd, GetCorrectWords(config));
        }

        [Test]
        public void ExcludeWordInConfigWithMethod()
        {
           var config = new ContentConfigurator();
            config.AddBoringWord("word1");
            config.AddBoringWord("word2");
            var exprectd = new List<string> { "word3", "word4" };
            Assert.AreEqual(exprectd, GetCorrectWords(config));
        }
    }
}
