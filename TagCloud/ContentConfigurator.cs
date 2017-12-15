using System.Collections.Generic;

namespace TagCloud
{
    public class ContentConfigurator : IWordFilter
    {
        private readonly HashSet<string> boringWords;
        private int minLenght;

        public ContentConfigurator()
        {
            boringWords = new HashSet<string>();
        }

        public ContentConfigurator(HashSet<string> boringWords)
        {
            this.boringWords = boringWords;
        }

        public IWordFilter AddBoringWord(string word)
        {
            boringWords.Add(word);
            return this;
        }


        public IWordFilter SetMinCountSymbolInWord(int lenght)
        {
            minLenght = lenght;
            return this;
        }

        public bool ValidWord(string word)
        {
            return !boringWords.Contains(word) && word.Length >= minLenght;
        }

    }
}
