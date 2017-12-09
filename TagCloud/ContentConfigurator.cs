using System.Collections.Generic;

namespace TagCloud
{
    class ContentConfigurator
    {
        private readonly HashSet<string> boringWords;

        public ContentConfigurator()
        {
            boringWords = new HashSet<string>();
        }

        public ContentConfigurator(HashSet<string> boringWords)
        {
            this.boringWords = boringWords;
        }

        public ContentConfigurator AddBoringWord(string word)
        {
            boringWords.Add(word);
            return this;
        }

        public bool ValidWord(string word)
        {
            return !boringWords.Contains(word);
        }
    }
}
