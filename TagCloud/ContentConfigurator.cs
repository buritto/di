using System.Collections.Generic;

namespace TagCloud
{
    class ContentConfigurator
    {
        private readonly HashSet<string> boringWords;

        public ContentConfigurator(HashSet<string> boringWords)
        {
            this.boringWords = boringWords;
        }

        public ContentConfigurator AddBoringWord(string word)
        {
            boringWords.Add(word);
            return this;
        }
    }
}
